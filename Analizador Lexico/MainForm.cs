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
            char[] cadena = txtEntrada.Text.ToCharArray();
            int i = 0;
            string conca = "";
            while (i < cadena.Length)
            {
                x.Rows.Add();
                if (cadena[i] == ' ' || cadena[i] == '\n' || cadena[i] == '\t')
                    i = i + 1;

                else if (cadena[i] == '+')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "+";
                    dtaTokens.Rows[h].Cells[1].Value = "5";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Op Suma";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '-')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "-";
                    dtaTokens.Rows[h].Cells[1].Value = "5";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Op Suma";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '*')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "*";
                    dtaTokens.Rows[h].Cells[1].Value = "6";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Op Mul";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '/')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "/";
                    dtaTokens.Rows[h].Cells[1].Value = "6";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Op Mul";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '<')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "<";
                    dtaTokens.Rows[h].Cells[1].Value = "7";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Op Relac";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '>')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = ">";
                    dtaTokens.Rows[h].Cells[1].Value = "7";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Op Relac";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '!')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "!";
                    dtaTokens.Rows[h].Cells[1].Value = "10";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Op OR";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '(')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "(";
                    dtaTokens.Rows[h].Cells[1].Value = "14";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Paréntesis";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == ';')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = ";";
                    dtaTokens.Rows[h].Cells[1].Value = "12";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Punto y coma";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == ',')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = ",";
                    dtaTokens.Rows[h].Cells[1].Value = "13";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Coma";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '(')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "(";
                    dtaTokens.Rows[h].Cells[1].Value = "14";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Paréntesis";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == ')')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = ")";
                    dtaTokens.Rows[h].Cells[1].Value = "15";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Paréntesis";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '{')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "{";
                    dtaTokens.Rows[h].Cells[1].Value = "16";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Llave";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '}')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "}";
                    dtaTokens.Rows[h].Cells[1].Value = "17";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Llave";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '=')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "=";
                    dtaTokens.Rows[h].Cells[1].Value = "18";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Igual";//Se muestra si es válida o no en una columna
                    h++;
                }
                else if (cadena[i] == '$')
                {
                    i = i + 1;
                    x.Rows.Add();
                    dtaTokens.Rows[h].Cells[0].Value = "$";
                    dtaTokens.Rows[h].Cells[1].Value = "23";//Se muestra qué tipo es en una columna
                    dtaTokens.Rows[h].Cells[2].Value = "Signo de peso";//Se muestra si es válida o no en una columna
                    h++;
                }


                else if (char.IsLetter(cadena[i]))
                {
                    y = i;
                    conca = conca + cadena[i];
                    i = i + 1;
                }
                if (i < cadena.Length)
                {
                    while (char.IsLetter(cadena[i]) || cadena[i] == '_')
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
                        if (char.IsDigit(cadena[i]) || cadena[i] == '.')
                        {
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
                int h = 0, f = 0;
                string cad;

                analizar(h);

                for (f = 0; f < dtaTokens.Rows.Count - 1; f++)
                {
                    cad = Convert.ToString(dtaTokens.Rows[f].Cells[0].Value);
                    if (cad == "int")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "4";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Tipo";
                    }
                    else if (cad == "float")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "4";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Tipo";
                    }
                    else if (cad == "void")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "4";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Tipo";
                    }
                    else if (cad == "<=")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "7";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Op Relac";
                    }
                    else if (cad == ">=")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "7";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Op Relac";
                    }
                    else if (cad == "==")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "11";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Op igualdad";
                    }
                    else if (cad == "!=")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "11";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Op igualdad";
                    }
                    else if (cad == "if")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "19";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Palabra reservada";
                    }
                    else if (cad == "while")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "20";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Palabra reservada";
                    }
                    else if (cad == "return")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "21";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Palabra reservada";
                    }
                    else if (cad == "else")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "22";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Palabra reservada";
                    }
                    else if (cad == "return")
                    {
                        dtaTokens.Rows[f].Cells[1].Value = "21";//Se muestra qué tipo es en una columna
                        dtaTokens.Rows[f].Cells[2].Value = "Palabra reservada";
                    }

                    if (dtaTokens.Rows[f].Cells[0].Value != null)
                    {
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
