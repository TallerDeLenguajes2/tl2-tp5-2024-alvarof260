public class Producto
{
    private int idProducto;
    private string descripcion;
    private int precio;

    public Producto(int idProducto, string descripcion, int precio) {
        this.IdProducto = idProducto;
        this.Descripcion = descripcion;
        this.Precio = precio;
    }

    public int IdProducto { get => idProducto; set => idProducto = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Precio { get => precio; set => precio = value; }
}