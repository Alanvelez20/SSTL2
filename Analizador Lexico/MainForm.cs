/*
 * INCO     SSPP Traductores 2
 * Vélez Gómez Alan David
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Analizador_Lexico
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            dtaTokens.DataSource = x.DefaultView;
        }
        
        int y;
        DataTable x = new DataTable();


        void analizar(int h)
        {
            char[] cadena =txtEntrada.Text.ToCharArray();
            int i = 0;
            string conca="";
            while (i < cadena.Length)
            {
                x.Rows.Add();
                if (cadena[i] == ' ' || cadena[i] == '\n' || cadena[i] == '\t' )
                    i = i + 1;

                else if (char.IsLetter(cadena[i]))
                {
                    y = i;
                    conca = conca + cadena[i];
                    i = i + 1;
                }
                if (i < cadena.Length)
                {
                    while (char.IsLetter(cadena[i]) || cadena[i] == '_' )
                    {
                        conca = conca + cadena[i];
                        i = i + 1;
                        dtaTokens.Rows[h].Cells[1].Value = "0";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[h].Cells[2].Value = "Identificador de variable";//Se muestra si es válida o no en una columna
                        if (i == cadena.Length)
                            break;
                    }
                }
                if (i < cadena.Length)
                {

                    while (char.IsDigit(cadena[i]) || cadena[i] == '.')
                    {
                        if (char.IsDigit(cadena[i]) || cadena[i] == '.') { 
                        conca = conca + cadena[i];
                        i = i + 1;

                        if (i == cadena.Length)
                            break;
                        }
                    }

                }
                dtaTokens.Rows[h].Cells[0].Value = conca;
                h++;
                conca = "";


            }
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Hace lo de adentro de las llaves si se presiona esta tecla
            {
                int h=0,f=0;
                string cad;

                analizar(h);

                for (f = 0; f < dtaTokens.Rows.Count - 1; f++)
                {
                    cad = Convert.ToString(dtaTokens.Rows[f].Cells[0].Value);
                    
                    if (dtaTokens.Rows[f].Cells[0].Value != null) { 
                        if (dtaTokens.Rows[f].Cells[1].Value == null)
                        {
                            bool b = cad.Contains(".");
                            if (b == true)
                            {
                                dtaTokens.Rows[f].Cells[1].Value = "2";//Se muestra qué tipo es en una columna
                                dtaTokens.Rows[f].Cells[2].Value = "Real";//Se muestra si es válida o no en una columna
                                b = false;
                            }
                            else if (b == false)
                            {
                                dtaTokens.Rows[f].Cells[1].Value = "1";
                                dtaTokens.Rows[f].Cells[2].Value = "Entero";//Se muestra si es válida o no en una columna
                            }
                        }
                    }
                }
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)//Botón Limpiar
        {
            x.Rows.Clear();//Se limpia lo que hay en las columnas
            txtEntrada.Text = "";//Se limpia la entrada
        }
    }
}
