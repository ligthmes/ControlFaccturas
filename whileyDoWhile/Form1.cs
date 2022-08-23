namespace whileyDoWhile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblMonto.Text = (0).ToString("C");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro de salir", "Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
                this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int i;
            // Calcular los datos
            int numfact = int.Parse(txtNumfact.Text);
            string licencia = cboTipo.Text;
            int unidades = int.Parse(txtUnidades.Text);

            //Determianr el precio de la licencia
            double precio = 0;
            switch(licencia)
            {
                case "Cobre": precio = 700; break;
                case "Bronce": precio = 900; break;
                case "Silver": precio = 1400;break;
                case "Gold": precio = 2500; break;
            }

            //Caluclando subtotal 
            double subtotal = unidades * precio;

            //Enviado la informacion a la lista de registro
            ListViewItem fila = new ListViewItem(numfact.ToString());
            fila.SubItems.Add(licencia);
            fila.SubItems.Add(unidades.ToString());
            fila.SubItems.Add(subtotal.ToString("0.00"));
            lvListadoRegistro.Items.Add(fila);

            //Calculando el monto total acumulado
            double acumulado = 0;
            i = 0;
            while(i < lvListadoRegistro.Items.Count)
            {
                acumulado += double.Parse(lvListadoRegistro.Items[i].SubItems[3].Text);
                i++;

            }
            lblMonto.Text  = acumulado.ToString("C"); 
            
            // Calculando las estadistica
            int cCobre =0 ,  cBronce = 0, cSilver = 0, cGold= 0;
            double tCobre = 0, tBronce = 0, tSilver = 0, tGold = 0;

            i = 0;
            do
            {
                if(lvListadoRegistro.Items[i].SubItems[1].Text== "Cobre")
                {
                    cCobre += int.Parse(lvListadoRegistro.Items[i].SubItems[2].Text);
                    tCobre += double.Parse(lvListadoRegistro.Items[i].SubItems[3].Text); 

                }
                if(lvListadoRegistro.Items[i].SubItems[1].Text== "Bronce")
                {
                    cBronce += int.Parse(lvListadoRegistro.Items[i].SubItems[2].Text);
                    tBronce  += double.Parse(lvListadoRegistro.Items[i].SubItems[3].Text);
                  
                }
                if (lvListadoRegistro.Items[i].SubItems[1].Text == "Silver")
                {
                    cSilver += int.Parse(lvListadoRegistro.Items[i].SubItems[2].Text);
                    tSilver += double.Parse(lvListadoRegistro.Items[i].SubItems[3].Text);
                }
                if( lvListadoRegistro.Items[i].SubItems[1].Text =="Gold")
                {
                    cGold += int.Parse(lvListadoRegistro.Items[i].SubItems[2].Text);
                    tGold += double.Parse(lvListadoRegistro.Items[i].SubItems[3].Text);
                }
                i++;
            } while(i < lvListadoRegistro.Items.Count);

            //Imprimiento estadistica 
            lvEstadistica.Items.Clear();
            string[] elementosfila = new string[3];
            ListViewItem row;

            elementosfila[0] = "Total Cobre";
            elementosfila[1] = cCobre.ToString();
            elementosfila[2] = tCobre.ToString();
            row = new ListViewItem(elementosfila);
            lvEstadistica.Items.Add(row);

            elementosfila[0] = "Total Bronce";
            elementosfila[1] = cBronce.ToString();
            elementosfila[2] = tBronce.ToString();
            row = new ListViewItem(elementosfila);
            lvEstadistica.Items.Add(row);

            elementosfila[0] = "Total Silver";
            elementosfila[1] = cSilver.ToString();
            elementosfila[2] = tSilver.ToString();
            row = new ListViewItem(elementosfila);
            lvEstadistica.Items.Add(row);

            elementosfila[0] = "Total Gold";
            elementosfila[1] = cGold.ToString();
            elementosfila[2] = tGold.ToString();
            row = new ListViewItem(elementosfila);
            lvEstadistica.Items.Add(row);

        }

        private void btnfactua_Click(object sender, EventArgs e)
        {
            txtNumfact.Clear();
            txtVendedor.Clear();
            txtUnidades.Clear();
            cboTipo.Text = "(Seleccione licencia)";
            txtNumfact.Focus();
        }
    }
}