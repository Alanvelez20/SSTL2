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
        
        int i;
        string texto;
        DataTable x = new DataTable();
        

        /*void analizar()
        {
            char[] cadena =txtEntrada.Text.ToCharArray();
            int i = 0;
            string conca="";
            while(i< cadena.Length)
            {
                x.Rows.Add();
                if (cadena[i] == ' ' || cadena[i] == '\n' || cadena[i] == '\t')
                    i=i+1;
                else if (char.IsLetter(cadena[i]))
                {
                    y=i;
                    conca = conca + cadena[i];
                    i = i+1;
                }
                if(i < cadena.Length -1)
                {
                    while(char.IsLetterOrDigit(cadena[i]) || cadena[i] == '_')
                    {
                        conca =conca + cadena[i];
                        i=i+1;
                        if(i==cadena.Length)
                            break;
                    }
                    
                }
                funcion(conca);
                conca = "";
            }
        }

        private void funcion(string conca)
        {
            switch (conca)
            {

            }
        }
        

        private void insertar(string token, int tipo, string simbolo)
        {
            x.Rows.Add();//indica que se agregará algo al DataGridView

        }*/
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Hace lo de adentro de las llaves si se presiona esta tecla
            {
                //analizar();
                int estado = 0;//Indica los estados por los que pasará la cadena
                char c;
                texto = txtEntrada.Text;//Es la cadena que ingresa el usuario
                int h, entradas = 0;

                entradas++;

                for (h = 0; h < entradas; h++)
                {

                    x.Rows.Add();//indica que se agregará algo al DataGridView

                    for (i = 0; i < txtEntrada.TextLength; i++)
                    {

                        c = texto[i];//c contendrá cada uno de los dígitos de la cadena

                        if (texto[i] == ' ' || texto[i] == '\n' || texto[i] == '\t')
                        {
                            h++;
                        }

                        dtaTokens.Rows[h].Cells[0].Value = Convert.ToString(texto);//Se agregará a la primer columna cada uno de los dígitos de la cadena
                                                                                   //
                        switch (estado)//Lee el estado en el que se encuentra actualmente para irse a la opcion correspondiente
                        {

                            case 0: //Es el estado 0, donde se encuentra el puntero
                                if (Char.IsLetter(c))//Letra Identificador de variable
                                {
                                    estado = 1;//Indica el estado al que pasará
                                    dtaTokens.Rows[h].Cells[1].Value = "0";//Se muestra qué tipo es en una columna
                                    dtaTokens.Rows[h].Cells[2].Value = "Letra";//Se muestra si es válida o no en una columna

                                }
                                else if (Char.IsDigit(c))//Dígito
                                {
                                    estado = 2;//Indica el estado al que pasará
                                    dtaTokens.Rows[h].Cells[1].Value = "1";//Se muestra qué tipo es en una columna
                                    dtaTokens.Rows[h].Cells[2].Value = "Entero";//Se muestra si es válida o no en una columna
                                }
                                else if (c != '+' || !Char.IsDigit(c) || !Char.IsLetter(c))//invalidaciones
                                {
                                    dtaTokens.Rows[h].Cells[2].Value = "No válida";//Se muestra si es válida o no en una columna
                                }
                                break;

                            case 1:
                                if (Char.IsLetterOrDigit(c))//Identificador de variable
                                {
                                    estado = 1;//Indica el estado al que pasará
                                    dtaTokens.Rows[h].Cells[1].Value = "0";// Se muestra qué tipo es en una columna
                                    dtaTokens.Rows[h].Cells[2].Value = "Identificador de variable";//Se muestra si es válida o no en una columna
                                }
                                else if (!Char.IsLetterOrDigit(c))//Invalidaciones
                                {
                                    dtaTokens.Rows[h].Cells[2].Value = "No válida";//Se muestra si es válida o no en una columna
                                }
                                break;
                            case 2:
                                if (Char.IsDigit(c))//Dígito
                                {
                                    estado = 2;//Indica el estado al que pasará
                                    dtaTokens.Rows[h].Cells[1].Value = "1";// Se muestra qué tipo es en una columna
                                    dtaTokens.Rows[h].Cells[2].Value = "Entero";//Se muestra si es válida o no en una columna
                                }
                                else if (c == '.')//Punto
                                {
                                    estado = 3;//Indica el estado al que pasará
                                }
                                else if (c != '.' || !Char.IsDigit(c))//invalidaciones
                                {
                                    dtaTokens.Rows[h].Cells[2].Value = "No válida";//Se muestra si es válida o no en una columna
                                }

                                break;
                            case 3:
                                if (Char.IsDigit(c))//Digito
                                {
                                    estado = 3;//Indica el estado al que pasará
                                    dtaTokens.Rows[h].Cells[1].Value = "2";// Se muestra qué tipo es en una columna
                                    dtaTokens.Rows[h].Cells[2].Value = "Real";//Se muestra si es válida o no en una columna

                                }
                                else if (!Char.IsDigit(c))//Invalidación
                                {
                                    dtaTokens.Rows[h].Cells[2].Value = "No válida";//Se muestra si es válida o no en una columna
                                }
                                break;

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
