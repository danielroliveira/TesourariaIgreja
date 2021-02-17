using System.Windows.Forms;

namespace CamadaUC
{
	public class ucDataGridView : DataGridView
	{
		protected override bool ProcessDialogKey(Keys keyData)
		{
			Keys key = keyData & Keys.KeyCode;

			if (key == Keys.Enter)
			{
				base.OnKeyDown(new KeyEventArgs(keyData));
				return true;
			}
			else
			{
				return base.ProcessDialogKey(keyData);
			}
		}
	}
}
