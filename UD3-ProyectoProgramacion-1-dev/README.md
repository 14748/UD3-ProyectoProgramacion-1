
# Wordle Clon

Este es un proyecto propuesto por el profesorado de programación de 1Dam del centro Cuatrovientos. El objetivo es desarrollar una réplica del popular juego Wordle utilizando Visual Basic .NET y todos los conocimientos adquiridos hasta la fecha, además de, por supuesto, todo el conocimiento que logremos adquirir por nuestra cuenta.

## Introduccion

Wordle es un juego de adivinanza de palabras en el que el jugador tiene que adivinar una palabra aleatoria de cinco letras dentro de un número limitado de intentos. Cada suposición se verifica contra la palabra objetivo, y se proporciona retroalimentación en forma de puntos de colores que indican cuántas letras son correctas y están en la posición correcta (puntos verdes) o son correctas pero están en la posición incorrecta (puntos amarillos). El jugador gana si adivina la palabra dentro de los intentos permitidos.

## Objetivos del proyecto

El objetivo principal de este proyecto es profundizar en nuestra comprensión de la programación con Visual Basic .NET y mejorar nuestras habilidades de resolución de problemas. Específicamente, buscamos:

* Crear una réplica funcional de Wordle que se adhiera a las reglas del juego.
* Utilizar Visual Basic .NET para implementar la lógica del juego, la interfaz de usuario y el sistema de retroalimentación.
* Probar y depurar el código para asegurarnos de que funcione según lo previsto.
* Aprender nuevos conceptos y técnicas de programación según sea necesario para completar el proyecto.

## Estructura del proyecto

* Form1.vb 
    * El código define la interfaz de usuario de un juego de palabras llamado "Wordle". Crea una cuadrícula de 6 filas y 5 columnas de etiquetas en la ventana. El usuario puede ingresar letras en cada etiqueta utilizando el teclado y, cuando se ingresa una palabra completa, el programa verifica si la palabra es válida en el diccionario. Si la palabra es válida, las letras de la palabra ingresada se resaltan con diferentes colores en la cuadrícula.

* Diccionario.vb 
    * Esta clase se utiliza para leer un archivo de texto que contiene palabras y su dificultad y cargarlos en una lista. Además, tiene métodos para agregar una palabra a la lista, validar si una palabra existe en la lista, obtener una palabra aleatoria de una cierta dificultad y un método que compara dos palabras y devuelve un array de enteros indicando si las letras coinciden (0), si una letra coincide pero no está en la misma posición (1) o si no coincide ninguna letra (2).

* Palabra.vb 
    * El archivo "palabra.vb" define una clase llamada "Palabra" que tiene tres propiedades: Texto, Dificultad y NumeroLetras. Estas propiedades se inicializan a través del constructor de la clase.

* KeyboardListener
    * Este código define una clase KeyboardListener que permite escuchar y manejar eventos de teclado en una aplicación de Windows. Utiliza la función SetWindowsHookEx para establecer un gancho global de teclado de nivel inferior (LowLevelKeyboardProc) que permite interceptar eventos de teclado antes de que se envíen al control de destino. Luego, cuando se detecta un evento de teclado, se invoca un manejador de eventos que permite procesar el evento en el código de la aplicación. La clase KeyboardListener tiene los eventos KeyDown y KeyUp que se pueden utilizar para detectar y manejar las pulsaciones de teclas en la aplicación. Además, la clase implementa la interfaz IDisposable para permitir la liberación de recursos no administrados cuando se termina de utilizar la clase.
## Autores

- [@Ricardo Álvarez](https://github.com/14748)
- [@Xabier Palo](https://github.com/XabierAPC)
- [@Rúben Igual](https://github.com/innombrable234)
