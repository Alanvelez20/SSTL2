/*
 * Traductores de lenguajes 2
 * Sección D05
 * Maestro: Erasmo Gabriel Marinez Soltero
 * 
 * Vélez Gómez Alan David
 * Código: 216804649
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Diagnostics;

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
            txtEntrada.Focus();
        }
        string texto;
        int i, inc = 0;
        DataTable x = new DataTable();
        public void Lexico()//Función del lexico
        {
            int estado = 0;//Indica los estados por los que pasará la cadena
            char c;
            string conca = "";
            texto = txtEntrada.Text + '$';//Es la cadena que ingresa el usuario
            for (i = 0; i < texto.Length; i++)//Indica que lo que esté dentro se repetirá en cada uno de los digitos de la cadena
            {
                c = texto[i];
                x.Rows.Add();
                switch (estado)
                {
                    case 0:
                        if (Char.IsLetter(c))//Letra Identificador de variable
                        {
                            estado = 1;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (Char.IsDigit(c))//Dígito
                        {
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (c == '.')//Punto
                        {
                            conca = conca + c;
                            estado = 3;
                        }
                        else if (c == '+')//Suma
                        {
                            dtaTokens.Rows[inc].Cells[0].Value = "+";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpSuma";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "14";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '-')//Resta
                        {
                            dtaTokens.Rows[inc].Cells[0].Value = "-";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpSuma";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "14";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '*')//Multi
                        {
                            dtaTokens.Rows[inc].Cells[0].Value = "*";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpMultiplicación";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "16";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '/')//Division
                        {
                            dtaTokens.Rows[inc].Cells[0].Value = "/";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpMultiplicación";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "16";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == ';')//punto y coma
                        {
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ";";
                            dtaTokens.Rows[inc].Cells[1].Value = "Punto y coma";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "2";
                            inc++;
                            conca = "";
                        }
                        else if (c == ',')//coma
                        {
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ",";
                            dtaTokens.Rows[inc].Cells[1].Value = "Coma";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "3";
                            inc++;
                            conca = "";
                        }
                        else if (c == '(')//parentesis izquierdo
                        {
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "(";
                            dtaTokens.Rows[inc].Cells[1].Value = "Parentesis izquierda";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "4";
                            inc++;
                            conca = "";
                        }
                        else if (c == ')')//parentesis derecho
                        {
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ")";
                            dtaTokens.Rows[inc].Cells[1].Value = "Parentesis derecha";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "5";
                            inc++;
                            conca = "";
                        }
                        else if (c == '{')//parentesis izquierdo
                        {
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "{";
                            dtaTokens.Rows[inc].Cells[1].Value = "Llave izquierda";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "6";
                            inc++;
                            conca = "";
                        }
                        else if (c == '}')//parentesis derecho
                        {
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "}";
                            dtaTokens.Rows[inc].Cells[1].Value = "Llave derecha";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "7";
                            inc++;
                            conca = "";
                        }
                        else if (c == '=')//parentesis derecho
                        {
                            conca = "";
                            conca = conca + c;
                            estado = 5;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "=";
                            dtaTokens.Rows[inc].Cells[1].Value = "Igual";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "8";
                            //inc++;
                            //conca = "";
                        }
                        else if (c == '<')//parentesis derecho
                        {
                            conca = "";
                            conca = conca + c;
                            estado = 6;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "<";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            //inc++;
                            //conca = "";
                        }
                        else if (c == '>')//parentesis derecho
                        {
                            conca = "";
                            conca = conca + c;
                            estado = 7;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ">";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            //inc++;
                            //conca = "";
                        }
                        else if (c == '!')//parentesis derecho
                        {
                            conca = "";
                            conca = conca + c;
                            estado = 8;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "!";
                            dtaTokens.Rows[inc].Cells[1].Value = "Error (Falta un = )";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            //inc++;
                            //conca = "";
                        }
                        else if (c == '|')//parentesis derecho
                        {
                            conca = "";
                            conca = conca + c;
                            estado = 9;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "|";
                            dtaTokens.Rows[inc].Cells[1].Value = "Error (Debe ser || )";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "Error";
                            //inc++;
                            //conca = "";
                        }
                        else if (c == '&')//parentesis derecho
                        {
                            conca = "";
                            conca = conca + c;
                            estado = 10;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "&";
                            dtaTokens.Rows[inc].Cells[1].Value = "Error (Debe ser && )";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "Error";
                            //inc++;
                            //conca = "";
                        }
                        else if (c == '$')//Pesos
                        {
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t' || !Char.IsDigit(c) || !Char.IsLetter(c))//Espacios y no validos
                        {
                            //inc++;
                            conca = "";
                            conca = conca + c;
                            estado = 0;
                        }
                        break;

                    case 1:
                        if (Char.IsLetterOrDigit(c) || c == '_')//Identificador de variable
                        {
                            estado = 1;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (c == '+')//suma
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "+";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpSuma";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "14";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '-')//resta
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "-";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpSuma";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "14";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '*')//multi
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "*";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpMultiplicación";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "16";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '/')//div
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "/";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpMultiplicación";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "16";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '.')//punto
                        {
                            conca = conca + c;
                            estado = 3;
                        }
                        else if (c == ';')//punto y coma
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ";";
                            dtaTokens.Rows[inc].Cells[1].Value = "Punto y coma";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "2";
                            inc++;
                            conca = "";
                        }
                        else if (c == ',')//coma
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ",";
                            dtaTokens.Rows[inc].Cells[1].Value = "Coma";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "3";
                            inc++;
                            conca = "";
                        }
                        else if (c == '(')//parentesis izquierdo
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "(";
                            dtaTokens.Rows[inc].Cells[1].Value = "Parentesis izq";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "4";
                            inc++;
                            conca = "";
                        }
                        else if (c == ')')//parentesis derecho
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ")";
                            dtaTokens.Rows[inc].Cells[1].Value = "Parentesis der";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "5";
                            inc++;
                            conca = "";
                        }
                        else if (c == '{')//parentesis izquierdo
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "{";
                            dtaTokens.Rows[inc].Cells[1].Value = "Llave izq";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "6";
                            inc++;
                            conca = "";
                        }
                        else if (c == '}')//parentesis derecho
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "}";
                            dtaTokens.Rows[inc].Cells[1].Value = "Llave der";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "7";
                            inc++;
                            conca = "";
                        }
                        else if (c == '=')//igual
                        {
                            inc++;
                            estado = 5;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "=";
                            dtaTokens.Rows[inc].Cells[1].Value = "Igual";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "8";
                            //conca = "";
                        }
                        else if (c == '<')//menor q
                        {
                            inc++;
                            estado = 6;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "<";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            //conca = "";
                        }
                        else if (c == '>')//mayor q
                        {
                            inc++;
                            estado = 7;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = ">";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            //conca = "";
                        }
                        else if (c == '!')//diferente
                        {
                            inc++;
                            estado = 8;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "!";
                            dtaTokens.Rows[inc].Cells[1].Value = "Diferente (OpRelacional)";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            //conca = "";
                        }
                        else if (c == '|')//barra vertical
                        {
                            inc++;
                            estado = 9;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "|";
                            dtaTokens.Rows[inc].Cells[1].Value = "Error (Falta un | )";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "Error";
                            //conca = "";
                        }
                        else if (c == '&')//barra vertical
                        {
                            inc++;
                            estado = 10;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "&";
                            dtaTokens.Rows[inc].Cells[1].Value = "Error (Falta un & )";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "Error";
                            //conca = "";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else
                        {
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;
                    case 2:
                        if (Char.IsDigit(c))//Dígito
                        {
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (Char.IsLetterOrDigit(c) || c == '_')//Identificador de variable
                        {
                            inc++;
                            estado = 1;//Indica el estado al que pasará
                            conca = "";
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (c == '+')//suma
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "+";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpSuma";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "14";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '-')//resta
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "-";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpSuma";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "14";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '*')//multi
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "*";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpMultiplicación";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "16";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '/')//div
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "/";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpMultiplicación";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "16";
                            conca = "";
                            inc++;
                            estado = 4;
                        }
                        else if (c == '.')//punto
                        {
                            conca = conca + c;
                            estado = 3;
                        }
                        else if (c == ';')//punto y coma
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ";";
                            dtaTokens.Rows[inc].Cells[1].Value = "Punto y coma";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "2";
                            inc++;
                            conca = "";
                        }
                        else if (c == ',')//coma
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ",";
                            dtaTokens.Rows[inc].Cells[1].Value = "Coma";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "3";
                            inc++;
                            conca = "";
                        }
                        else if (c == '(')//parentesis izquierdo
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "(";
                            dtaTokens.Rows[inc].Cells[1].Value = "Parentesis izq";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "4";
                            inc++;
                            conca = "";
                        }
                        else if (c == ')')//parentesis derecho
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = ")";
                            dtaTokens.Rows[inc].Cells[1].Value = "Parentesis der";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "5";
                            inc++;
                            conca = "";
                        }
                        else if (c == '{')//parentesis izquierdo
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "{";
                            dtaTokens.Rows[inc].Cells[1].Value = "Llave izq";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "6";
                            inc++;
                            conca = "";
                        }
                        else if (c == '}')//parentesis derecho
                        {
                            inc++;
                            estado = 0;//Indica el estado al que pasará
                            dtaTokens.Rows[inc].Cells[0].Value = "}";
                            dtaTokens.Rows[inc].Cells[1].Value = "Llave der";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "7";
                            inc++;
                            conca = "";
                        }
                        else if (c == '=')//igual
                        {
                            inc++;
                            estado = 5;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "=";
                            dtaTokens.Rows[inc].Cells[1].Value = "Igual";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "8";
                            //conca = "";
                        }
                        else if (c == '<')//igual
                        {
                            inc++;
                            estado = 6;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "<";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            //conca = "";
                        }
                        else if (c == '>')//igual
                        {
                            inc++;
                            estado = 7;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = ">";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            //conca = "";
                        }
                        else if (c == '!')//igual
                        {
                            inc++;
                            estado = 8;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "!";
                            dtaTokens.Rows[inc].Cells[1].Value = "Diferente (OpRelacional)";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            //conca = "";
                        }
                        else if (c == '|')//barra vertical
                        {
                            inc++;
                            estado = 9;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "|";
                            dtaTokens.Rows[inc].Cells[1].Value = "Error (Falta un | )";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "Error";
                            //conca = "";
                        }
                        else if (c == '&')//barra vertical
                        {
                            inc++;
                            estado = 10;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "&";
                            dtaTokens.Rows[inc].Cells[1].Value = "Error (Falta un & )";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "Error";
                            //conca = "";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t')//espacios
                        {
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        else if (!Char.IsDigit(c) || c != '+' || c != '-' || c != '*' || c != '/' || c != '.')//Invalidación
                        {
                            inc++;
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;
                    case 3:
                        if (Char.IsDigit(c))//Dígito
                        {
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t' || !Char.IsDigit(c))//espacios e invalidacion
                        {
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;
                    case 4:
                        if (Char.IsDigit(c))//Dígito
                        {
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (Char.IsLetterOrDigit(c) || c == '_')//Identificador de variable
                        {
                            estado = 1;//Indica el estado al que pasará
                            conca = "";
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t')//Invalidación
                        {
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        else if (!Char.IsDigit(c))//Invalidación
                        {
                            conca = conca + c;
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;
                    case 5:
                        if (c == '=')//igual
                        {
                            estado = 0;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "==";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            inc++;
                            conca = "";
                        }
                        else if (Char.IsDigit(c))//Dígito
                        {
                            inc++;
                            conca = "";
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (Char.IsLetterOrDigit(c) || c == '_')//Identificador de variable
                        {
                            inc++;
                            conca = "";
                            estado = 1;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t')//Invalidación
                        {
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        else
                        {
                            inc++;
                            conca = conca + c;
                            //dtaTokens.Rows[inc].Cells[0].Value = conca;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;
                    case 6:
                        if (c == '=')//igual
                        {
                            estado = 0;//Indica el estado al que pasará
                            //conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "<=";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            inc++;
                            conca = "";
                        }
                        else if (Char.IsDigit(c))//Dígito
                        {
                            inc++;
                            conca = "";
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (Char.IsLetterOrDigit(c) || c == '_')//Identificador de variable
                        {
                            inc++;
                            conca = "";
                            estado = 1;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t')//Invalidación
                        {
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        else
                        {
                            inc++;
                            //conca = conca + c;
                            //dtaTokens.Rows[inc].Cells[0].Value = conca;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;
                    case 7:
                        if (c == '=')//igual
                        {
                            estado = 0;//Indica el estado al que pasará
                            //conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = ">=";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            inc++;
                            conca = "";
                        }
                        else if (Char.IsDigit(c))//Dígito
                        {
                            inc++;
                            conca = "";
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (Char.IsLetterOrDigit(c) || c == '_')//Identificador de variable
                        {
                            inc++;
                            conca = "";
                            estado = 1;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t')//Invalidación
                        {
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        else
                        {
                            inc++;
                            conca = conca + c;
                            //dtaTokens.Rows[inc].Cells[0].Value = conca;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;
                    case 8:
                        if (c == '=')//igual
                        {
                            estado = 0;//Indica el estado al que pasará
                            //conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "!=";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpRelacional";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "17";
                            inc++;
                            conca = "";
                        }
                        else if (Char.IsDigit(c))//Dígito
                        {
                            inc++;
                            conca = "";
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (Char.IsLetterOrDigit(c) || c == '_')//Identificador de variable
                        {
                            inc++;
                            conca = "";
                            estado = 1;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t')//Invalidación
                        {
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        else
                        {
                            inc++;
                            conca = conca + c;
                            //dtaTokens.Rows[inc].Cells[0].Value = conca;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;
                    case 9:
                        if (c == '|')//igual
                        {
                            estado = 0;//Indica el estado al que pasará
                            //conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "||";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpLógico";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "15";
                            inc++;
                            conca = "";
                        }
                        else if (Char.IsDigit(c))//Dígito
                        {
                            inc++;
                            conca = "";
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (Char.IsLetterOrDigit(c) || c == '_')//Identificador de variable
                        {
                            inc++;
                            conca = "";
                            estado = 1;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t')//Invalidación
                        {
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        else
                        {
                            inc++;
                            //conca = conca + c;
                            //dtaTokens.Rows[inc].Cells[0].Value = conca;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;
                    case 10:
                        if (c == '&')//igual
                        {
                            estado = 0;//Indica el estado al que pasará
                            //conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = "&&";
                            dtaTokens.Rows[inc].Cells[1].Value = "OpLógico";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "15";
                            inc++;
                            conca = "";
                        }
                        else if (Char.IsDigit(c))//Dígito
                        {
                            inc++;
                            conca = "";
                            estado = 2;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Constante";//Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "13";
                        }
                        else if (Char.IsLetterOrDigit(c) || c == '_')//Identificador de variable
                        {
                            inc++;
                            conca = "";
                            estado = 1;//Indica el estado al que pasará
                            conca = conca + c;
                            dtaTokens.Rows[inc].Cells[0].Value = conca;
                            dtaTokens.Rows[inc].Cells[1].Value = "Id";
                            dtaTokens.Rows[inc].Cells[2].Value = "1";
                        }
                        else if (c == '$')//pesos
                        {
                            inc++;
                            dtaTokens.Rows[inc].Cells[0].Value = "$";
                            dtaTokens.Rows[inc].Cells[1].Value = "Pesos";// Se muestra qué tipo es en una columna
                            dtaTokens.Rows[inc].Cells[2].Value = "18";
                            estado = 20;
                        }
                        else if (c == ' ' || c == '\n' || c == '\t')//Invalidación
                        {
                            inc++;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        else
                        {
                            inc++;
                            //conca = conca + c;
                            //dtaTokens.Rows[inc].Cells[0].Value = conca;
                            estado = 0;
                            conca = "";
                            conca = conca + c;
                        }
                        break;


                    case 20://Fin de estados
                        estado = 0;
                        break;

                }
            }
            string tipo = "", valor = "";
            //int tipo2= Convert.ToInt32(dtaTokens.Rows[inc].Cells[2].Value);

            for (int i = 0; i < x.Rows.Count; i++)
            {
                tipo = Convert.ToString(dtaTokens.Rows[i].Cells[1].Value);
                valor = Convert.ToString(dtaTokens.Rows[i].Cells[0].Value);
                if (tipo == "Id")
                {
                    if (valor == "int" || valor == " int" || valor == "\nint")
                    {
                        dtaTokens.Rows[i].Cells[1].Value = "Tipo de dato";
                        dtaTokens.Rows[i].Cells[2].Value = "0";
                    }
                    if (valor == "float" || valor == " float" || valor == "\nfloat")
                    {
                        dtaTokens.Rows[i].Cells[1].Value = "Tipo de dato";
                        dtaTokens.Rows[i].Cells[2].Value = "0";
                    }
                    if (valor == "char" || valor == " char" || valor == "\nchar")
                    {
                        dtaTokens.Rows[i].Cells[1].Value = "Tipo de dato";
                        dtaTokens.Rows[i].Cells[2].Value = "0";
                    }
                    if (valor == "void" || valor == " void" || valor == "\nvoid")
                    {
                        dtaTokens.Rows[i].Cells[1].Value = "Tipo de dato";
                        dtaTokens.Rows[i].Cells[2].Value = "0";
                    }
                    if (valor == "if" || valor == " if" || valor == "\nif")
                    {
                        dtaTokens.Rows[i].Cells[1].Value = "if";
                        dtaTokens.Rows[i].Cells[2].Value = "9";
                    }
                    if (valor == "while" || valor == " while" || valor == "\nwhile")
                    {
                        dtaTokens.Rows[i].Cells[1].Value = "while";
                        dtaTokens.Rows[i].Cells[2].Value = "10";
                    }
                    if (valor == "return" || valor == " return" || valor == "\nreturn")
                    {
                        dtaTokens.Rows[i].Cells[1].Value = "return";
                        dtaTokens.Rows[i].Cells[2].Value = "11";
                    }
                    if (valor == "else" || valor == " else" || valor == "\nelse")
                    {
                        dtaTokens.Rows[i].Cells[1].Value = "else";
                        dtaTokens.Rows[i].Cells[2].Value = "12";
                    }
                }
            }
        }

        //Nodos del arbol
        public class NodoArbol
        {
            public string Valor { get; set; }
            public List<NodoArbol> Hijos { get; set; }

            public NodoArbol(string valor)
            {
                Valor = valor;
                Hijos = new List<NodoArbol>();
            }
        }
        int bandera = 0;
        public NodoArbol GenerarArbol()
        {
            // Ruta del archivo de texto
            string filePath = "GR2slrRulesId.txt";
            string filePath2 = "GR2slrTable.txt";

            // Leemos todas las líneas del archivo
            string[] lines = File.ReadAllLines(filePath);
            string[] linesT = File.ReadAllLines(filePath2);

            // Creamos las matrices para tabla y reglas
            int filas = lines.Length;
            int col = lines[0].Split('\t').Length;
            int[,] RulesId = new int[filas, col];

            int filasT = linesT.Length;
            int colT = linesT[0].Split('\t').Length;
            int[,] Tablas = new int[filasT, colT];

            // Guardamos las reglas en una matriz
            for (int i = 0; i < filas; i++)
            {
                string[] elements = lines[i].Split('\t');

                // Agregamos cada elemento a la matriz
                for (int j = 0; j < col; j++)
                {
                    RulesId[i, j] = int.Parse(elements[j]);
                }
            }
            //Guardamos la tabla en una matriz
            for (int r = 0; r < filasT; r++)
            {
                string[] elementos = linesT[r].Split('\t');

                // Agregamos cada elemento a la matriz
                for (int f = 0; f < colT; f++)
                {
                    Tablas[r, f] = int.Parse(elementos[f]);
                }
            }
            Stack<NodoArbol> pilaNodos = new Stack<NodoArbol>();
            Stack<int> pilaEstados = new Stack<int>();
            pilaEstados.Push(0);

            int indice = 0;
            int row;
            int accion,t, newRow;
            //bool band = true;
            int regla;

            while (true)
            {
                row = pilaEstados.Peek();
                int columna = Convert.ToInt32(dtaTokens.Rows[indice].Cells[2].Value);
                accion = Tablas[row, columna];
                // Desplazamiento
                if (accion >= 1)
                {
                    
                    var nodoTerminal = new NodoArbol(dtaTokens.Rows[indice].Cells[0].Value.ToString());
                    pilaNodos.Push(nodoTerminal);
                    pilaEstados.Push(columna);
                    pilaEstados.Push(accion);
                    indice++;
                }
                // Reducción
                else if (accion < -1)
                {
                    row = accion;
                    row = row * -1;
                    row = row - 1;
                    regla = RulesId[row, 1] * 2;
                    t = 0;
                    while (t < regla)
                    {
                        pilaEstados.Pop();
                        t++;
                    }

                    columna = RulesId[row, 0];
                    newRow = pilaEstados.Peek();
                    pilaEstados.Push(columna);
                    pilaEstados.Push(Tablas[newRow, columna]);
                }
                // Error de análisis sintáctico
                else if (accion == 0)
                {
                    //band = false;
                    lblValido.Text = "NO válido";
                    lblValido.BackColor = Color.Red;
                    lblSemantico.Text = "NO válido";
                    lblSemantico.BackColor = Color.Red;
                    return null;
                }
                // Análisis sintáctico exitoso
                else if (accion == -1)
                {
                    //band = false;
                    bandera = 1;
                    lblValido.Text = "Válido";
                    lblValido.BackColor = Color.Green;
                    lblSemantico.Text = "Válido";
                    lblSemantico.BackColor = Color.Green;
                    return pilaNodos.Pop();
                }
            }
        }

        /*public void sintactico()
        {
            // Ruta del archivo de texto
            string filePath = "GR2slrRulesId.txt";
            string filePath2 = "GR2slrTable.txt";

            // Leemos todas las líneas del archivo
            string[] lines = File.ReadAllLines(filePath);
            string[] linesT = File.ReadAllLines(filePath2);

            // Creamos las matrices para tabla y reglas
            int filas = lines.Length;
            int col = lines[0].Split('\t').Length;
            int[,] RulesId = new int[filas, col];

            int filasT = linesT.Length;
            int colT = linesT[0].Split('\t').Length;
            int[,] Tablas = new int[filasT, colT];

            // Guardamos las reglas en una matriz
            for (int i = 0; i < filas; i++)
            {
                string[] elements = lines[i].Split('\t');

                // Agregamos cada elemento a la matriz
                for (int j = 0; j < col; j++)
                {
                    RulesId[i, j] = int.Parse(elements[j]);
                }
            }
            //Guardamos la tabla en una matriz
            for (int r = 0; r < filasT; r++)
            {
                string[] elementos = linesT[r].Split('\t');

                // Agregamos cada elemento a la matriz
                for (int f = 0; f < colT; f++)
                {
                    Tablas[r, f] = int.Parse(elementos[f]);
                }
            }

            
            //Sintactico
            Stack<int> lista = new Stack<int>();
            lista.Push(0);
            int row, column;
            bool band = true;
            int inc = 0;
            int accion;
            int regla;
            int t, newRow;

            


                //While para analizar la cadena
                while (band == true)
                {
                    row = lista.Peek();
                    column = Convert.ToInt32(dtaTokens.Rows[inc].Cells[2].Value);
                    accion = Tablas[row, column];
                    //Desplazamiento
                    if (accion >= 1)
                    {
                        lista.Push(column);
                        lista.Push(accion);
                        inc++;
                    }
                    //Reduccion
                    else if (accion < -1)
                    {
                        row = accion;
                        row = row * -1;
                        row = row - 1;
                        regla = RulesId[row, 1] * 2;
                        t = 0;
                        while (t < regla)
                        {
                            lista.Pop();
                            t++;
                        }
                        column = RulesId[row, 0];
                        newRow = lista.Peek();
                        lista.Push(column);
                        lista.Push(Tablas[newRow, column]);
                    }
                    else if (accion == 0)
                    {
                        band = false;
                        lblValido.Text = "NO válido";
                        lblValido.BackColor = Color.Red;
                        //bandera = 1;
                    }
                    else if (accion == -1)
                    {
                        band = false;
                        lblValido.Text = "Válido";
                        lblValido.BackColor = Color.Green;
                    }
                }
            }*/
        
        private void btnLimpiar_Click(object sender, EventArgs e)//Botón Limpiar
        {
            x.Rows.Clear();//Se limpia lo que hay en las columnas
            txtEntrada.Text = "";//Se limpia la entrada
            txtEnsamblador.Text = "";
            lblValido.Text = "";
            lblValido.BackColor = Color.Transparent;
            lblSemantico.Text = "";
            lblSemantico.BackColor = Color.Transparent;
            inc = 0;
        }

        /*void GenerarCodigo()
        {

            var provider = CodeDomProvider.CreateProvider("CSharp");

            //Crear el exe
            var options = new CompilerParameters
            {
                GenerateExecutable = true, // Generar un archivo ejecutable
                OutputAssembly = "CodigoGenerado.exe" // Nombre del archivo ejecutable generado
            };

            //Código a compilar
            var code = Convert.ToString(txtEntrada);


            // Compilar el código
            var results = provider.CompileAssemblyFromSource(options, code);

            if (results.Errors.HasErrors)
            {
                Console.WriteLine("Error de compilación:");
                foreach (CompilerError error in results.Errors)
                {
                    Console.WriteLine("{0}: {1}", error.ErrorNumber, error.ErrorText);
                }
            }
            else
            {
                Console.WriteLine("Compilación exitosa");

                // Cargar y ejecutar el archivo generado
                var assembly = Assembly.LoadFrom("CodigoGenerado.exe");
                var programType = assembly.GetType("CodigoGenerado.Program");
                var mainMethod = programType.GetMethod("Main", BindingFlags.Static | BindingFlags.Public);
                mainMethod.Invoke(null, new object[] {});
            }
         }*/
        void GenerarCodigo() {
            string codigoEnsamblador = txtEnsamblador.Text;
            
            string rutaArchivo = "C:\\emu8086\\MySource\\codigo.asm";
            File.WriteAllText(rutaArchivo, codigoEnsamblador);

            string emu8086Path = "\"C:\\emu8086\\emu8086.exe\"";
            string parametros = "C:\\emu8086\\MySource\\codigo.asm";
            Process.Start(emu8086Path,parametros);

            //Hacer ejecutable
            string Codigo = txtEntrada.Text;
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardInput = true,
                UseShellExecute = false
            };

            Process cmdProcess = new Process()
            {
                StartInfo = startInfo
            };

            cmdProcess.Start();
            // Escribir el contenido en la consola de CMD
            cmdProcess.StandardInput.WriteLine(Codigo);
            //cmdProcess.StandardInput.WriteLine("exit");

            // Esperar a que el proceso de CMD se cierre
            //cmdProcess.WaitForExit();

            //Console.WriteLine("Presione cualquier tecla para salir...");
            //Console.ReadKey();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            Lexico();//Analisis lexico y acomoda los tokens
            GenerarArbol();//Analisis sintactico y semantico
            if (bandera == 1)
            {
                if (txtEnsamblador.Text == "")
                {
                    txtEnsamblador.Text = "Vacío";
                }
                else
                {
                    GenerarCodigo();//Genera el código solamente si son válidos los analisis anteriores
                }

            }
            else
            {
                txtEnsamblador.Text = "No se puede convertir";
            }
            
        }
    }
}
