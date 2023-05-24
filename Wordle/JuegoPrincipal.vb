Imports System.Drawing.Text
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports WordleClases
Imports WorldleUtilidades
Public Class JuegoPrincipal
    ReadOnly appender As New AppendMessageOnScreen
    Private WithEvents escuchadorDeTeclado As KeyboardListener
    Const numeroColumnas As Integer = 5
    Const tamañoLabel As Integer = 50
    Const margenEntreLabels As Integer = 10
    Const caracteresPermitidos As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"

    Dim celdaActual As Integer
    Dim celdaMaximaDeFila As Integer
    Dim celdaMinimaDeFila As Integer
    Dim palabraDeFilaActual As String

    Dim pnlJuegoPrincipal As Panel
    Dim pnlInteriorClasificacion As Panel
    Dim pnlConfiguracion As New Panel With {
            .Dock = DockStyle.Fill,
            .BorderStyle = BorderStyle.FixedSingle,
            .Visible = True,
            .BackColor = Color.Black
        }

    Dim haCargadoElJuego As Boolean = False

    Dim haAccionadoClasificacion As Boolean = False



    ReadOnly cboSelectorDificultad As New ComboBox With {
            .Width = 100,
            .Height = tamañoLabel,
            .Left = 160, '((tamanoLabel + tamanoLabel) + tamanoMargen) + tamanoMargen,
            .Top = 102, '((tamanoLabel + tamanoLabel) + tamanoMargen) + tamanoMargen,
            .Text = "Normal",
            .Font = New Font("Arial", 10, FontStyle.Bold)
        }
    ReadOnly lblDificultad As New Label With {
            .Width = 500,
            .Height = 50,
            .Left = 130%,
            .Top = 60,
            .Text = "Dificultad",
            .Font = New Font("Arial", 18, FontStyle.Bold)
    }

    ''' <summary>
    ''' Maneja el evento Load del formulario Form1. Realiza acciones al cargar el formulario.
    ''' - Inicializa la lista de arrays en Globales para almacenar objetos del tipo Diccionario.TipoAcierto.
    ''' - Establece el estado de la ventana a maximizado.
    ''' - Remueve los controles pnlConfiguracion y cboSelectorDificultad del formulario.
    ''' - Agrega las opciones de dificultad ("Normal", "Avanzado", "Experto") al ComboBox cboSelectorDificultad.
    ''' - Oculta los botones btnCerrarConfiguracion y btnAplicarConfiguracion.
    ''' - Agrega el label lblDificultad al panel pnlConfiguracion.
    ''' - Oculta el panel pnlClasificacion.
    ''' - Llama al método cargarJuego para realizar las acciones correspondientes al cargar el juego.
    ''' - Establece el estado haCargadoElJuego como verdadero.
    ''' </summary>
    ''' <param name="sender">El objeto que generó el evento (el formulario Form1).</param>
    ''' <param name="e">Los argumentos del evento.</param>

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Globales.listaDeAciertosWordle = New List(Of Diccionario.TipoAcierto())()
        Me.WindowState = FormWindowState.Maximized
        Me.Controls.Remove(pnlConfiguracion)
        Me.Controls.Remove(cboSelectorDificultad)

        cboSelectorDificultad.Items.AddRange({"Normal", "Avanzado", "Experto"})
        btnCerrarConfiguracion.Hide()
        btnAplicarConfiguracion.Hide()
        pnlConfiguracion.Controls.Add(lblDificultad)
        pnlClasificacion.Hide()

        cargarJuego()

        haCargadoElJuego = True
    End Sub

    ''' <summary>
    ''' Carga el juego y realiza las acciones necesarias para configurar la interfaz de usuario y las variables de juego.
    ''' - Obtiene una palabra aleatoria del diccionario utilizando el método GetRandomWord de la instancia de Globales.Instanciadicionario.
    ''' - Crea un nuevo Panel llamado grpContenedorTest que servirá como contenedor principal para los labels del juego.
    ''' - Establece el tamaño y el estilo de borde del panel grpContenedorTest.
    ''' - Asigna grpContenedorTest al panel pnlJuegoPrincipal del formulario.
    ''' - Alinea pnlJuegoPrincipal en el centro del formulario mediante el cálculo de sus coordenadas de ubicación.
    ''' - Agrega pnlJuegoPrincipal a la colección de controles del formulario.
    ''' - Crea un objeto Font con la fuente "Arial", tamaño 24 y estilo en negrita para los labels del juego.
    ''' - Utilizando bucles, crea y configura los labels del juego dentro de pnlJuegoPrincipal.
    ''' - Crea un nuevo label llamado lbl y lo hace invisible.
    ''' - Agrega lbl al panel pnlJuegoPrincipal.
    ''' - Establece los valores de celdaMaximaDeFila y celdaMinimaDeFila en función del número de columnas y la celda actual.
    ''' - Establece el estado haCargadoElJuego como verdadero.
    ''' - Crea una nueva instancia de KeyboardListener y la asigna a la variable escuchadorDeTeclado.
    ''' </summary>
    Private Sub cargarJuego()
        Globales.Instanciadicionario.GetRandomWord()

        Dim coordenadasEjeYCentroForm = Me.Height / 2
        Dim coordenadasEjeXCentroForm = Me.Width / 2

        Dim grpContenedorTest As New Panel With {
            .Size = New Size(numeroColumnas * (tamañoLabel + margenEntreLabels) + margenEntreLabels, Globales.numeroFilas * (tamañoLabel + margenEntreLabels) + margenEntreLabels),
            .BorderStyle = BorderStyle.None
        }
        pnlJuegoPrincipal = grpContenedorTest

        pnlJuegoPrincipal.Location = New Point((Me.Width - pnlJuegoPrincipal.Width) / 2, (Me.Height - pnlJuegoPrincipal.Height) / 2)

        Me.Controls.Add(pnlJuegoPrincipal)

        Dim font As New Font("Arial", 24, FontStyle.Bold)

        For row As Integer = 0 To Globales.numeroFilas - 1
            For col As Integer = 0 To numeroColumnas - 1
                Dim nuevoLabel As New Label With {
            .Width = tamañoLabel,
            .Height = tamañoLabel,
            .BorderStyle = BorderStyle.FixedSingle,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Location = New Point(col * (tamañoLabel + margenEntreLabels) + margenEntreLabels, row * (tamañoLabel + margenEntreLabels) + margenEntreLabels),
            .Font = font
        }
                pnlJuegoPrincipal.Controls.Add(nuevoLabel)
            Next
        Next

        Dim lbl As New Label With {.Visible = False}
        pnlJuegoPrincipal.Controls.Add(lbl)

        celdaMaximaDeFila = numeroColumnas + celdaActual
        celdaMinimaDeFila = celdaActual
        haCargadoElJuego = True
        escuchadorDeTeclado = New KeyboardListener()
    End Sub

    ''' <summary>
    ''' Maneja la entrada del usuario cuando se presiona la tecla "Enter".
    ''' Realiza operaciones lógicas y de interfaz basadas en la entrada y las reglas del juego.
    ''' Verifica si la celda actual es la última celda de la fila.
    ''' Trunca la palabra a la longitud especificada.
    ''' Valida la palabra truncada en el diccionario.
    ''' Actualiza la apariencia de las etiquetas y botones según los resultados de coincidencia.
    ''' Verifica si el jugador ha ganado el juego.
    ''' Actualiza los valores de las celdas y la palabra para la siguiente fila.
    ''' </summary>
    Private Sub EnterPresionado()
        If celdaActual <> celdaMaximaDeFila Then
            appender.CreateAnimatedLabel(Me, "No hay suficientes letras", pnlJuegoPrincipal.Location.X + (pnlJuegoPrincipal.Width / 2), pnlJuegoPrincipal.Location.Y)
            Exit Sub
        End If

        palabraDeFilaActual = palabraDeFilaActual.Substring(0, numeroColumnas)

        If Not Globales.Instanciadicionario.PalabraEsValida(palabraDeFilaActual) Then
            appender.CreateAnimatedLabel(Me, "La palabra introducida no existe en nuestro diccionario", pnlJuegoPrincipal.Location.X + (pnlJuegoPrincipal.Width / 2), pnlJuegoPrincipal.Location.Y)
            Exit Sub
        End If

        Dim estadoAciertosPalabraActua() As Diccionario.TipoAcierto = Globales.Instanciadicionario.GreenYellowGray(palabraDeFilaActual)
        Globales.listaDeAciertosWordle.Add(estadoAciertosPalabraActua)

        For i = 0 To palabraDeFilaActual.Length - 1
            Dim leterLabel As Label = CType(pnlJuegoPrincipal.Controls(i + celdaMinimaDeFila), Label)
            For Each control As Control In grpTeclado.Controls
                If TypeOf control Is Button Then
                    Dim button As Button = CType(control, Button)
                    If palabraDeFilaActual(i) = button.Text Then
                        If estadoAciertosPalabraActua(i) = Diccionario.TipoAcierto.Acertado Then
                            leterLabel.BackColor = ColorTranslator.FromHtml("#538d4e")
                            button.BackColor = ColorTranslator.FromHtml("#538d4e")
                        ElseIf estadoAciertosPalabraActua(i) = Diccionario.TipoAcierto.Regular Then
                            leterLabel.BackColor = ColorTranslator.FromHtml("#b59f3b")
                            button.BackColor = ColorTranslator.FromHtml("#b59f3b")
                        Else
                            leterLabel.BackColor = ColorTranslator.FromHtml("#3a3a3c")
                            button.BackColor = ColorTranslator.FromHtml("#3a3a3c")
                        End If
                    End If
                End If
            Next
        Next

        If Globales.Instanciadicionario.HaGanado(palabraDeFilaActual, celdaActual) Then
            Dim frm2 As New PartidaFinalizada
            frm2.Show()
            escuchadorDeTeclado.Dispose()
            Globales.listaUsuarios.GuardarUsuarios()
            Me.Dispose()
        End If

        celdaMaximaDeFila += numeroColumnas
        celdaMinimaDeFila += numeroColumnas
        palabraDeFilaActual = ""
    End Sub

    ''' <summary>
    ''' Maneja la acción cuando se presiona la tecla "Return". Elimina la última letra ingresada en el juego.
    ''' Verifica si la celda actual es mayor que la celda mínima permitida y, en ese caso, realiza las siguientes acciones:
    ''' - Actualiza la palabra actual eliminando la última letra.
    ''' - Borra el texto de la etiqueta correspondiente a la celda actual.
    ''' - Ajusta el valor de la celda actual, disminuyéndolo en uno.
    ''' - Muestra la palabra actualizada en la ventana de depuración.
    ''' </summary>
    ''' <param name="currentLabel">La etiqueta actual que se eliminará.</param>
    Private Sub ReturnPresionado(currentLabel As Label)
        If celdaActual > celdaMinimaDeFila Then
            palabraDeFilaActual = palabraDeFilaActual.Substring(0, palabraDeFilaActual.Length - 1)
            currentLabel = CType(pnlJuegoPrincipal.Controls(celdaActual - 1), Label)
            currentLabel.Text = ""
            celdaActual -= 1
            Debug.WriteLine(palabraDeFilaActual)
        End If
    End Sub

    ''' <summary>
    ''' Maneja la acción cuando se presiona una letra en el teclado del juego. Agrega la letra a la palabra actual y actualiza la interfaz.
    ''' Verifica si la celda actual no es igual a la celda máxima permitida y, en caso afirmativo, realiza las siguientes acciones:
    ''' - Aumenta el valor de la celda actual en uno.
    ''' - Asigna la letra al texto de la etiqueta actual.
    ''' - Agrega la letra a la palabra actual concatenándola.
    ''' </summary>
    ''' <param name="currentLabel">La etiqueta actual en la que se muestra la letra.</param>
    ''' <param name="letra">La letra presionada.</param>
    Private Sub LetraPresionada(currentLabel As Label, letra As String)
        If celdaActual <> celdaMaximaDeFila Then
            celdaActual += 1
            currentLabel.Text = letra
            palabraDeFilaActual += currentLabel.Text
        End If
    End Sub

    ''' <summary>
    ''' Maneja el evento clic de los botones de letras. Agrega la letra correspondiente a la palabra actual y actualiza la interfaz.
    ''' Verifica si la celda actual es menor o igual a la cantidad total de celdas permitidas en el juego.
    ''' En caso afirmativo, realiza las siguientes acciones:
    ''' - Obtiene el botón y la etiqueta actual correspondientes al estado de la celda actual.
    ''' - Llama al método LetraPresionada para agregar la letra a la palabra actual y actualizar la interfaz.
    ''' </summary>
    ''' <param name="sender">El botón que se ha presionado.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnQ.Click, btnW.Click, btnR.Click, btnT.Click, btnY.Click, btnU.Click, btnI.Click, btnE.Click, btnO.Click, btnP.Click, btnA.Click, btnS.Click, btnD.Click, btnF.Click, btnG.Click, btnH.Click, btnJ.Click, btnK.Click, btnL.Click, btnÑ.Click, btnZ.Click, btnX.Click, btnC.Click, btnV.Click, btnB.Click, btnN.Click, btnM.Click
        If celdaActual <= Globales.numeroFilas * numeroColumnas Then
            Dim button As Button = CType(sender, Button)
            Dim currentLabel As Label = CType(pnlJuegoPrincipal.Controls(celdaActual), Label)
            LetraPresionada(currentLabel, button.Text)
        End If
    End Sub

    ''' <summary>
    ''' Maneja el evento clic del botón "ENVIAR". Realiza las acciones correspondientes cuando se envía la palabra actual.
    ''' Verifica si la celda actual es menor o igual a la cantidad total de celdas permitidas en el juego.
    ''' En caso afirmativo, realiza las siguientes acciones:
    ''' - Llama al método EnterPresionado para procesar la palabra actual y realizar las validaciones y acciones correspondientes.
    ''' </summary>
    ''' <param name="sender">El botón "ENVIAR" que se ha presionado.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub btnENVIAR_Click(sender As Object, e As EventArgs) Handles btnENVIAR.Click
        If celdaActual <= Globales.numeroFilas * numeroColumnas Then
            EnterPresionado()
        End If
    End Sub

    ''' <summary>
    ''' Maneja el evento clic del botón "ELIMINAR". Realiza las acciones correspondientes para eliminar la última letra ingresada.
    ''' Verifica si la celda actual es menor o igual a la cantidad total de celdas permitidas en el juego.
    ''' En caso afirmativo, realiza las siguientes acciones:
    ''' - Obtiene la etiqueta actual correspondiente a la celda actual.
    ''' - Llama al método ReturnPresionado para eliminar la última letra ingresada.
    ''' </summary>
    ''' <param name="sender">El botón "ELIMINAR" que se ha presionado.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub btnELIMINAR_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If celdaActual <= Globales.numeroFilas * numeroColumnas Then
            Dim currentLabel As Label = CType(pnlJuegoPrincipal.Controls(celdaActual), Label)
            ReturnPresionado(currentLabel)
        End If
    End Sub

    ''' <summary>
    ''' Maneja el evento Resize del formulario. Realiza ajustes de posicionamiento en función del cambio de tamaño del formulario.
    ''' - Calcula la posición central en los ejes Y y X del formulario.
    ''' - Ajusta la ubicación del grupo de teclado en la parte inferior central del formulario.
    ''' - Ajusta la ubicación del grupo de menú en la parte superior central del formulario.
    ''' - Si el juego ha sido cargado, ajusta la ubicación del panel principal del juego en el centro del formulario.
    ''' </summary>
    ''' <param name="sender">El formulario.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim posY = Me.Height / 2
        Dim posX = Me.Width / 2

        grpTeclado.Location = New Point(posX - (grpTeclado.Size.Width / 2), Me.Height - grpTeclado.Size.Height - 30)
        grpMenu.Location = New Point(posX - (grpMenu.Size.Width / 2), 0)
        If haCargadoElJuego Then
            pnlJuegoPrincipal.Location = New Point((Me.Width - pnlJuegoPrincipal.Width) / 2, (Me.Height - pnlJuegoPrincipal.Height) / 2)
        End If
    End Sub

    ''' <summary>
    ''' Maneja el evento KeyDown del objeto KeyboardListener. Realiza acciones en función de la tecla presionada.
    ''' Verifica si la celda actual es menor o igual a la cantidad total de celdas permitidas en el juego.
    ''' En caso afirmativo, realiza las siguientes acciones según la tecla presionada:
    ''' - Si la tecla presionada es un carácter permitido (letra del abecedario o Ñ), llama al método LetraPresionada para agregar la letra a la palabra actual y actualizar la interfaz.
    ''' - Si la tecla presionada es la tecla de retroceso (Backspace), llama al método ReturnPresionado para eliminar la última letra ingresada.
    ''' - Si la tecla presionada es la tecla Enter (Return), llama al método EnterPresionado para procesar la palabra actual y realizar las validaciones y acciones correspondientes.
    ''' - Marca el evento como manipulado (Handled) para evitar que se propague a otros controladores de eventos.
    ''' </summary>
    ''' <param name="sender">El objeto KeyboardListener que generó el evento.</param>
    ''' <param name="e">Los argumentos del evento KeyDown.</param>
    Private Sub _keyboardListener_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles escuchadorDeTeclado.KeyDown

        Dim caracteresPermitidos As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"

        If celdaActual <= Globales.numeroFilas * numeroColumnas Then
            Dim currentLabel As Label = CType(pnlJuegoPrincipal.Controls(celdaActual), Label)
            Debug.WriteLine($"Current Label: {celdaActual}")

            If caracteresPermitidos.Contains(e.KeyCode.ToString().ToUpper()) OrElse e.KeyValue = 192 Then ''si no se ha pulsado eneter, se busca si la tecla esta en abecedario, si es asi haz ....
                LetraPresionada(currentLabel, If(e.KeyValue = 192, "Ñ", e.KeyCode.ToString()))
            End If

            If e.KeyCode = Keys.Back Then
                ReturnPresionado(currentLabel)
            End If

            If e.KeyCode = Keys.Return Then
                EnterPresionado()
            End If

            e.Handled = True
            Debug.WriteLine($"End Label: {celdaActual}")
            Debug.WriteLine(palabraDeFilaActual)
        End If
    End Sub

    ''' <summary>
    ''' Maneja el evento clic del botón "config". Realiza acciones para mostrar y configurar la ventana de configuración.
    ''' Agrega los controles necesarios al formulario y los muestra.
    ''' - Agrega el selector de dificultad (combobox) y el panel de configuración al formulario.
    ''' - Agrega los botones de cerrar configuración y aplicar configuración al panel de configuración.
    ''' - Muestra el panel de configuración, el selector de dificultad y los botones correspondientes.
    ''' - Asegura que el panel de configuración, los botones de cerrar y aplicar configuración, y el selector de dificultad se muestren en primer plano.
    ''' </summary>
    ''' <param name="sender">El botón "config" que se ha presionado.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub btnconfig_Click(sender As Object, e As EventArgs) Handles btnconfig.Click
        Me.Controls.Add(cboSelectorDificultad)
        Me.Controls.Add(pnlConfiguracion)

        pnlConfiguracion.Controls.Add(btnCerrarConfiguracion)
        pnlConfiguracion.Controls.Add(btnAplicarConfiguracion)
        pnlConfiguracion.Show()
        cboSelectorDificultad.Show()
        btnCerrarConfiguracion.Show()
        btnAplicarConfiguracion.Show()

        pnlConfiguracion.BringToFront()
        btnCerrarConfiguracion.BringToFront()
        btnAplicarConfiguracion.BringToFront()
        cboSelectorDificultad.BringToFront()
    End Sub

    ''' <summary>
    ''' Maneja el evento clic del botón "cerrar" en la ventana de configuración. Realiza acciones para cerrar y ocultar la ventana de configuración.
    ''' Remueve los controles correspondientes del formulario.
    ''' - Remueve el botón de cerrar configuración del panel de configuración y del formulario principal.
    ''' - Remueve el panel de configuración y el selector de dificultad del formulario principal.
    ''' Oculta el botón de cerrar configuración, el botón de aplicar configuración, el panel de configuración y el selector de dificultad.
    ''' </summary>
    ''' <param name="sender">El botón "cerrar" que se ha presionado.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub cerrar_Click(sender As Object, e As EventArgs) Handles btnCerrarConfiguracion.Click
        pnlConfiguracion.Controls.Remove(btnCerrarConfiguracion)
        Me.Controls.Remove(btnCerrarConfiguracion)
        Me.Controls.Remove(pnlConfiguracion)
        Me.Controls.Remove(cboSelectorDificultad)

        btnCerrarConfiguracion.Hide()
        btnAplicarConfiguracion.Hide()
        pnlConfiguracion.Hide()
        cboSelectorDificultad.Hide()

    End Sub

    ''' <summary>
    ''' Maneja el evento clic del botón "Aplicar Configuración" en la ventana de configuración. Realiza acciones para aplicar la configuración seleccionada.
    ''' Verifica si se ha seleccionado una opción de dificultad distinta a "Normal".
    ''' En caso afirmativo, realiza las siguientes acciones:
    ''' - Crea una nueva instancia del formulario JuegoPrincipal.
    ''' - Según la opción de dificultad seleccionada, establece el número de filas en función de la dificultad elegida.
    ''' - Muestra el formulario JuegoPrincipal.
    ''' - Cierra y libera los recursos del formulario actual.
    ''' </summary>
    ''' <param name="sender">El botón "Aplicar Configuración" que se ha presionado.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub btnApliConf_Click(sender As Object, e As EventArgs) Handles btnAplicarConfiguracion.Click
        If cboSelectorDificultad.SelectedItem <> "Normal" Then
            Dim a As New JuegoPrincipal
            If cboSelectorDificultad.SelectedItem = "Avanzado" Then
                Globales.numeroFilas = 6 - 1
            ElseIf cboSelectorDificultad.SelectedItem = "Experto" Then
                Globales.numeroFilas = 6 - 2
            Else
                Globales.numeroFilas = 6
            End If
            a.Show()
            Me.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Maneja el evento clic del botón "btnbarras" en la ventana de clasificación. Realiza acciones para mostrar u ocultar la clasificación.
    ''' Si no se ha accionado la clasificación anteriormente:
    ''' - Verifica si el panel "pnlInteriorClasificacion" es nulo. Si es así, crea el panel y agrega las etiquetas de encabezado y los datos de clasificación.
    ''' - Ajusta el tamaño y la posición del panel "pnlInteriorClasificacion" para que se muestre correctamente en el formulario.
    ''' - Agrega el panel "pnlInteriorClasificacion" al panel "pnlClasificacion".
    ''' - Muestra el panel "pnlClasificacion" y el panel "pnlInteriorClasificacion".
    ''' - Actualiza el estado de "haAccionadoClasificacion" a verdadero.
    ''' Si se ha accionado la clasificación anteriormente:
    ''' - Muestra u oculta el panel "pnlInteriorClasificacion" según su estado actual.
    ''' - Muestra u oculta el panel "pnlClasificacion" según su estado actual.
    ''' - Actualiza el estado de "haAccionadoClasificacion" a su estado opuesto.
    ''' </summary>
    ''' <param name="sender">El botón "btnbarras" que se ha presionado.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub btnbarras_Click(sender As Object, e As EventArgs) Handles btnbarras.Click
        If Not haAccionadoClasificacion Then
            If pnlInteriorClasificacion Is Nothing Then
                pnlInteriorClasificacion = New Panel()
                Dim headers As String() = {"Usuario", "Partidas Jugadas", "Partidas Ganadas", "Racha Actual", "Mejor Racha"}
                Dim left As Integer = 0
                Dim maxWidth As Integer = 0
                For Each header As String In headers
                    Dim headerLabel As New Label()
                    headerLabel.Text = header
                    headerLabel.Top = 0
                    headerLabel.Left = left
                    headerLabel.Font = New Font(headerLabel.Font, FontStyle.Bold)
                    pnlInteriorClasificacion.Controls.Add(headerLabel)
                    left += headerLabel.Width + 5
                    maxWidth = Math.Max(maxWidth, headerLabel.Width)
                Next

                Dim top As Integer = 30
                Dim ranking As List(Of Usuario) = Globales.listaUsuarios.GetRanking()
                Dim count As Integer = 0

                For Each usuario As Usuario In ranking
                    If count >= 8 Then
                        Exit For
                    End If

                    Dim labels() As Label = {New Label(), New Label(), New Label(), New Label(), New Label()}
                    Dim properties() As String = {usuario.Username, usuario.PartidasJugadas.ToString(), usuario.PartidasGanadas.ToString(), usuario.RachaActual.ToString(), usuario.MejorRacha.ToString()}
                    left = 0
                    For i As Integer = 0 To labels.Length - 1
                        labels(i).Text = properties(i)
                        labels(i).Top = top
                        labels(i).Left = left
                        labels(i).Width = maxWidth
                        labels(i).BorderStyle = BorderStyle.Fixed3D
                        pnlInteriorClasificacion.Controls.Add(labels(i))
                        left += labels(i).Width + 5
                    Next
                    top += 60
                    count += 1
                Next

                btnbarras.Location = New Point((pnlInteriorClasificacion.Width - btnbarras.Width) / 2, top + 10)
                pnlInteriorClasificacion.Controls.Add(btnbarras)

                pnlInteriorClasificacion.Width = left
                pnlInteriorClasificacion.Height = top + btnbarras.Height + 20
                pnlInteriorClasificacion.Location = New Point((pnlClasificacion.Width - pnlInteriorClasificacion.Width) / 2, (pnlClasificacion.Height - pnlInteriorClasificacion.Height) / 2)

                pnlClasificacion.Controls.Add(pnlInteriorClasificacion)
            Else
                pnlInteriorClasificacion.Show()
            End If

            pnlInteriorClasificacion.Controls.Add(btnbarras)
            btnbarras.Location = New Point((pnlInteriorClasificacion.Width - btnbarras.Width) / 2, pnlInteriorClasificacion.Height - btnbarras.Height - 10)

            pnlClasificacion.Show()
        Else
            grpMenu.Controls.Add(btnbarras)
            btnbarras.Location = New Point(1, 46)

            pnlInteriorClasificacion.Hide()
            pnlClasificacion.Hide()
        End If
        haAccionadoClasificacion = Not haAccionadoClasificacion
    End Sub

    ''' <summary>
    ''' Maneja el evento Deactivate del formulario principal. Realiza acciones cuando el formulario pierde el foco.
    ''' Si se ha cargado el juego previamente:
    ''' - Libera los recursos del escuchador de teclado llamando al método Dispose().
    ''' </summary>
    ''' <param name="sender">El objeto que generó el evento.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If haCargadoElJuego Then
            EscuchadorDeTeclado.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Maneja el evento Activated del formulario principal. Realiza acciones cuando el formulario obtiene el foco.
    ''' Si se ha cargado el juego previamente:
    ''' - Crea una nueva instancia del escuchador de teclado.
    ''' </summary>
    ''' <param name="sender">El objeto que generó el evento.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If haCargadoElJuego Then
            EscuchadorDeTeclado = New KeyboardListener()
        End If
    End Sub

    ''' <summary>
    ''' Maneja el evento FormClosed del formulario principal. Realiza acciones cuando el formulario se cierra.
    ''' - Realiza una salida del entorno de ejecución para terminar la aplicación.
    ''' </summary>
    ''' <param name="sender">El objeto que generó el evento.</param>
    ''' <param name="e">Los argumentos del evento.</param>
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Environment.Exit(0)
    End Sub
End Class