Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class KeyboardListener
    Implements IDisposable

    Private Delegate Function LowLevelKeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal lpfn As LowLevelKeyboardProc, ByVal hMod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function UnhookWindowsHookEx(ByVal hhk As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function CallNextHookEx(ByVal hhk As IntPtr, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_KEYUP As Integer = &H101

    Private _hookID As IntPtr
    Private _hookProc As LowLevelKeyboardProc

    Public Event KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
    Public Event KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)

    Public Sub New()
        _hookProc = AddressOf KeyboardProc
        _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _hookProc, IntPtr.Zero, 0)
        If _hookID = IntPtr.Zero Then
            Throw New Exception("Failed to set keyboard hook.")
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        UnhookWindowsHookEx(_hookID)
    End Sub

    Private Function KeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        If nCode >= 0 AndAlso (wParam = New IntPtr(WM_KEYDOWN) OrElse wParam = New IntPtr(WM_KEYUP)) Then
            Dim e As New KeyEventArgs(CType(Marshal.ReadInt32(lParam), Keys))
            If wParam = New IntPtr(WM_KEYDOWN) Then
                RaiseEvent KeyDown(Me, e)
            Else
                RaiseEvent KeyUp(Me, e)
            End If
            If e.Handled Then
                Return New IntPtr(1)
            End If
        End If
        Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
    End Function

End Class
