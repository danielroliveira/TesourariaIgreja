using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDTO;

namespace CamadaUI
{
	public partial class Form1 : Form
	{

		private BindingSource bind = new BindingSource();
		private objContribuinte Cont = new objContribuinte(null);
		private bool RegistroAlterado = false;

		public Form1()
		{
			InitializeComponent();

			//txtClienteNome.DataBindings.Add("Text", BindingCliente, "Cadastro", True, DataSourceUpdateMode.OnPropertyChanged)

			bind.DataSource = Cont;
			textBox1.DataBindings.Add("Text", bind, "Contribuinte", true, DataSourceUpdateMode.OnPropertyChanged);

			Cont.PropertyChanged += Alterado;

		}

		private void Alterado(object sender, PropertyChangedEventArgs e)
		{
			if (RegistroAlterado == false)
			{
				MessageBox.Show("Alterado");
				RegistroAlterado = true;
			}
		}
	}
}
