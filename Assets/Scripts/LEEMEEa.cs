using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEEMEEa : MonoBehaviour
{
    /*Hola Erik, que tal :D.

    [v 2.0]
    Cosas realizadas.
    [1] ▲ Las estructuras ya no están en el canvas, ahora están fuera del canvas.
    [2] ▲ La camara se mueve hacía abajo hasta llegar al principio cuando pierdes.

    Cosas que falta:
    [1] Detectar ciertos puntajes (10, 20, 50 y 100 puntos). 
    |-----► Podemos hacer que, si la estructura cayó centrada, entonces esto le de más puntos al jugador.

    [2] Mejorar sistema de fisicas.
    |-----► Las estructuras no quedan muy bien en ciertas situaciones.

    [3] Falta todo lo escrito en la sección [v 1.0].

        [v 1.0]
        Cosas que falta:
        [1] Configurar el volumen de la música y efectos de sonido.
        |-----► No hay nada con respecto a la música, así que puedes agregar la música que quieras para hacer las pruebas, luego decidimos que música dejaremos 
        |-----| de fondo y para efectos. 
        |-----► Puedes hacer una barra de scroll para controlar el volumen. Dejalo con el sprite default, el domingo haré los sprites para dejarlo bonito.
        |-----► Si necesitas más botones, que no sea alguno de los que están en la carpeta "Prefabs", crea un botón default y usalo con la sprite que tenga. 
        |-----| Me avisas y le hago un pixel art y animación.
        |-----► Lee la nota que está al final para esta sección.

        [4] Particulas cuando las estructuras caen.
        |-----► Cuando la estructura haya caido en el centro, sería bacan que hubiera un efecto de particulas (Así como en minecraft que se crean particulas en el suelo cuando corres).
        |-----| Podrías ver como lo hacen en Minecraft para tenerlo de referencia.
        |-----► Podría haber algún efecto de particulas cuando la estructura haya caido en una esquina.

        [5] Pantalla de carga entre escenas.
        |-----► Pues eso mismo, una pantalla de carga entre escenas, para que no se sienta tan brusco el cambio.

        [6] Difuminado del fondo cuando estemos en la configuración o en el panel de "reintentar o volver al menú".
        |----► En el menú, sería bacan que el fondo se viera difuminado cuando estemos en el panel de configuración. Investigué, y parece que se puede hacer con un paquete externo
        |----| llamado "Post processing", que debería dejarnos crear gameobject's de tipo "Volume", pero no sé porque no está. Lo instale, pero no encontré la forma de usarlo. 
        |----| Así que ahí puedes ver que onda.

        [] Algunos problemas esteticos y funcionales [].
        |-----► Hay veces que cuando la estructura cae y choca con la estructura base, esta queda dentro del Box Collider de la estructura base, dejando un efecto extraño. 
        |-----| Esto puede ser por la masa de la estructura o por el multiplicador de la gravedad (Todo esto se puede ver en el componente RigidBody2D en el prefab "Estructura").
        |-----► Podrías intentar mejorar la detección de cuando la estructura queda fuera de la pantalla y el jugador pierde, siento que hay posibilidades de que no funcione 
        |-----| en todos los casos.
        |-----► Si en algún momento te pasa que las estructuras, luego de haber caido, te hayan quedado más arriba, dejando aire entremedio, esto puede deberse por el 
        |-----| script "Estructura.cs", seguramente no se destruyó el script en la línea 31 (Destroy(this.gameObject.GetComponent<Estructura>())), dando la posibilidad
        |-----| a este error extraño. Si esto te pasa, tendríamos que revisar como solucionarlo definitivamente.

        [Nota]
        .Si en algún momento arrastras un prefab al canvas, y este no se ve, asegurate de que el gameobject que hayas agregado este dentro de "canvas" en la jerarquia.
        .Hay un tema con el pivote con las cosas que estan en el canvas. La verdad no he investigado, pero supongo que tiene que ver con el cambio de la relación de aspecto de 
        la ventana donde estamos jugando, de tal forma que las cosas estén "agarradas" a un lugar de la pantalla. Aunque esto es algo que veriamos al final del proyecto.
        .Si le cambias el nombre a un script, y luego todo deja de funcionar, recuerda también cambiar el nombre de la clase dentro del mismo script.
        .Las estructuras serán menos anchas, ya que está muy facil con el tamaño que tienen ahora.
    */
}
