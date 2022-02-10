namespace Api_Crud_Mysql_Core_MVC.Models
{
    public class Deposito
    {
        public Deposito()
        {

        }

        int id;
        string area;

        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string marca;

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
