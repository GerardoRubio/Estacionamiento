using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamiento
{
    class ListaSimple<Tipo> where Tipo : IComparable<Tipo>, IEquatable<Tipo>
    {
        private ClaseNodo NodoInicial;

        private class ClaseNodo
        {
            private Tipo objetocondatos; // Objeto conlos datos del nodo
            private ClaseNodo siguiente; // Apuntadoral siguiente nodo lógico
            public Tipo ObjetoConDatos
            {
                get { return objetocondatos; }
                set { objetocondatos = value; }
            }
            // Propiedad pública del apuntador alsiguiente nodo
            public ClaseNodo Siguiente
            {
                get { return siguiente; }
                set { siguiente = value; }
            }
        }
        public ListaSimple()
        {
            NodoInicial = null; // Inicializa la listasimple vacía
        }
        public bool EstaVacia()
        {
            return NodoInicial == null;
        }
        public void Insertar(Tipo Nodo)
        {
            ClaseNodo NuevoNodo, NodoActual, NodoAnterior;
            if (EstaVacia())
            {
                NuevoNodo = new ClaseNodo(); //Creacióndel nuevo nodo
                NuevoNodo.ObjetoConDatos = Nodo; //Asignación de los datos del Nodo
                NuevoNodo.Siguiente = null; // ElNuevoNodo apunta a nulo
                NodoInicial = NuevoNodo; // Ahora elNuevoNodo es el NodoInicial
                return; // Inserción exitosa
            }
            // Recorrido de la Lista
            NodoActual = NodoInicial; // Inicializa elrecorrido en el NodoInicial
            NodoAnterior = NodoInicial; // Guarda elNodoAnterior
            do
            {
                // Comparación para verificar duplicado
                if (NodoActual.ObjetoConDatos.CompareTo(Nodo) == 0)
                    throw new Exception("Duplicado..."); // No se inserta el dato (duplicado)
                if (Nodo.CompareTo(NodoActual.ObjetoConDatos) < 0)
                {
                    // Alta al principio de la Lista
                    if (Nodo.CompareTo(NodoInicial.ObjetoConDatos) < 0)
                    {
                        NuevoNodo = new ClaseNodo();
                        //Creación del nuevo nodo
                        NuevoNodo.ObjetoConDatos = Nodo; // Asignación de los datos del Nodo
                        NuevoNodo.Siguiente = NodoInicial; // El NuevoNodo apunta al NodoInicial
                        NodoInicial = NuevoNodo; //Ahora el NodoInicial es el NuevoNodo
                        return; // Inserción exitosa
                    }
                    else
                    {
                        // Alta de un Dato intermedioen la Lista
                        NuevoNodo = new ClaseNodo();
                        //Creación del nuevo nodo
                        NuevoNodo.ObjetoConDatos = Nodo; // Asignación de los datos del Nodo
                        NuevoNodo.Siguiente = NodoAnterior.Siguiente; // El NuevoNodo apunta alNodoAnterior
                        NodoAnterior.Siguiente = NuevoNodo; // El NodoAnterior apunta al NuevoNodo
                        return; // Inserción exitosa
                    }
                }
                NodoAnterior = NodoActual; // Guardael NodoAnterior
                NodoActual = NodoActual.Siguiente; //Se mueve al siguiente nodo del NodoActual
            } while (NodoActual != null); // Repetir mientras no se encuentre el final de la Lista
                                          // Alta de un Dato al final de la Lista
            NuevoNodo = new ClaseNodo(); //Creación delnuevo nodo
            NuevoNodo.ObjetoConDatos = Nodo; //Asignación de los datos del Nodo
            NuevoNodo.Siguiente = null; // El NuevoNodo no apunta a nada(es el último de la lista)
            NodoAnterior.Siguiente = NuevoNodo; // ElNodoAnterior apunta al NuevoNodo
            return; // Inserción exitosa
        }
        public Tipo Eliminar(Tipo Nodo)
        {
            ClaseNodo NodoActual, NodoAnterior;
            if (EstaVacia())
                return default(Tipo);
            //return throw new Exception("Vacia...");
            NodoActual = NodoInicial;
            NodoAnterior = NodoInicial; // Guarda el NodoAnterior
            do
            {

                if (Nodo.Equals(NodoActual.ObjetoConDatos)) // Verifica si es el Nodo que desea borrar
                {
                    // Eliminación del primer nodo de la lista
                    if (Nodo.Equals(NodoInicial.ObjetoConDatos)) // ¿Es elprimer nodo de la lista ?
                    {
                        NodoInicial = NodoActual.Siguiente; // El NodoInicial ahora es al queapunta el NodoActual
                        NodoActual.Siguiente = null; //Se eliminael Nodo Actual
                        return (NodoActual.ObjetoConDatos); // Eliminación exitosa(devuelve los datos del nodo eliminado)
                    }
                    else
                    {
                        // Eliminación de un nodointermedio o el ultimo nodo de la lista
                        NodoAnterior.Siguiente = NodoActual.Siguiente; // El NodoAnterior apunta alsiguiente nodo del actual
                        NodoActual.Siguiente = null;//Se eliminael Nodo Actual
                        return (NodoActual.ObjetoConDatos); // Eliminación exitosa(devuelve los datos del nodo eliminado)
                    }
                }
                NodoAnterior = NodoActual; // Guarda el NodoAnterior
                NodoActual = NodoActual.Siguiente; //Cambia de NodoActual
            } while (NodoActual != null);
            throw new Exception("No se encuentra ...");
        }
        public void Vaciar()
        {
            if (!EstaVacia())
            {
                ClaseNodo NodoActual = NodoInicial;
                ClaseNodo NodoAnterior;
                // Recorre la lista
                while (NodoActual != null) // Mientras no encuentra el final de la lista
                {
                    NodoAnterior = NodoActual; //Guarda el NodoAnterior
                    NodoActual = NodoActual.Siguiente;
                    // Cambia de NodoActual
                    //NodoAnterior = null; // Elimina el NodoAnterior
                    NodoAnterior.Siguiente = null;
                }
                NodoInicial = null; // Inicializa la lista vacía
            }
            else
                throw new Exception("Vacía ...");
        }
        public IEnumerator<Tipo> GetEnumerator()
        {
            if (EstaVacia())
                yield break;
            ClaseNodo NodoActual = new ClaseNodo();
            // Inicia el recorrido de la lista en el NodoInicial
            NodoActual = NodoInicial;
            while (NodoActual != null) // Mientras haya nodos ...
            {
                yield return (Tipo)NodoActual.ObjetoConDatos; // Devuelve los datos del NodoActual
                NodoActual = NodoActual.Siguiente; //Cambia de NodoActual
            }
        }
        public Tipo Buscar(Tipo Nodo)
        {
            if (!EstaVacia())
            {
                ClaseNodo NodoActual = NodoInicial;
                while (NodoActual != null) // Mientrasno encuentra el final de la lista
                {
                    if (Nodo.Equals(NodoActual.ObjetoConDatos)) // ¿Es el nodo deseado ?
                        return NodoActual.ObjetoConDatos; // Búsqueda exitosa (devuelve los datos del nodo buscado)
                    NodoActual = NodoActual.Siguiente;// Cambia de NodoActual
                }
                return default; // Terminó elrecorrido y no se encuentra el dato
            }
            else
                return default; // No seencuentra el dato(lista simple vacía)
        }


    }
}
