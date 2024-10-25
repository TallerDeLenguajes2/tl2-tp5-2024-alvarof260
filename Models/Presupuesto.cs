public class Presupuesto
{
    private int idPresupuesto;
    private string nombreDestinario;
    private List<PresupuestoDetalle> detalle;
    private static double iva = 0.21;

    public Presupuesto(int idPresupuesto, string nombreDestinario) {
        this.IdPresupuesto = idPresupuesto;
        this.NombreDestinario = nombreDestinario;
    }

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinario { get => nombreDestinario; set => nombreDestinario = value; }
    public List<PresupuestoDetalle> Detalle { get => detalle; set => detalle = value; }

    public int MontoPresupuesto()
    {
        int monto = 0;

        foreach (var presupuesto in Detalle)
        {
            monto += presupuesto.Producto.Precio * presupuesto.Cantidad;
        }

        return monto;
    }
    

    public double montoPresupuestoConIva()
    {
        double montoConIva = 0;
        double precio = 0;
        
        foreach (var presupuesto in Detalle)
        {
            precio = presupuesto.Producto.Precio * presupuesto.Cantidad;
            montoConIva += precio + (precio * iva);
        }

        return montoConIva;
    }

    public int CantidadProductos()
    {
        int cantidad = 0;
        foreach (var presupuesto in Detalle)
        {
            cantidad += presupuesto.Cantidad;
        }

        return cantidad;
    }

}