#include <iostream>
#include <cstdlib>
#include<windows.h>

using namespace std;

//VALIDACION
bool entero(char *a);
char cadena[100];
void error(){
    cout<<"\nEste dato no es valido, intenta de nuevo..."<<endl;
}
int validar(string a){
    do{
        cout<<a;
        cin>>cadena;
        if(!entero(cadena)){
        error();
        }
      }while(!entero(cadena));
    return atoi(cadena);
}
bool entero(char *a){
    for(int i = 0; i<strlen(a); i++){
        if(!isdigit(a[i])){
            return false;
        }
    }
    return true;
}
//CLASE
class Nodo{
  public:
    string value;
    Nodo* next;
};

void push(Nodo *&pila, string n){
  Nodo *temp = new Nodo();
  temp->value = n;
  temp->next = pila;
  pila = temp;
};

void pop(Nodo *&pila){
  Nodo *temp = pila;
  pila = temp->next;
  delete(temp);
};

void gotoxy(int x,int y){
      HANDLE hcon;
      hcon = GetStdHandle(STD_OUTPUT_HANDLE);
      COORD dwPos;
      dwPos.X = x;
      dwPos.Y= y;
      SetConsoleCursorPosition(hcon,dwPos);
 }

void peek(Nodo *&pila){
    Nodo *temp = pila;
    int y=10;
    gotoxy(50,y++);
    printf("\t%c%c%c%c%c\n",201,205,205,205,187);
    gotoxy(48,y++);
    printf("TOPE -> %c ",186);
    cout<<temp->value; printf(" %c\n",186);
    gotoxy(50,y++);
    printf("\t%c%c%c%c%c\n",200,205,205,205,188);
    gotoxy(40,y++);
    system("pause");
}

void display(Nodo *&pila){
    Nodo *temp = pila;
    int i=5;
    while(temp!=NULL){
        if(temp==pila){
            gotoxy(50,i++);
            printf("\t%c%c%c%c%c\n",201,188,250,200,187);
            gotoxy(50,i++);
            printf("\t%c",186);
            cout <<" "<<temp->value<<" ";
            printf("%c\n",186);
            temp=temp->next;
        }else{
            gotoxy(50,i++);
            printf("\t%c%c%c%c%c\n",204,205,205,205,185);
            gotoxy(50,i++);
            printf("\t%c",186);
            cout <<" "<<temp->value<<" ";
            printf("%c\n",186);
            temp=temp->next;
        }
    }
    gotoxy(50,i++);
    printf("\t%c%c%c%c%c\n",200,205,205,205,188);
    gotoxy(40,i++);
    system("pause");
    cout << endl;
}

int menu(){
    int opc;
    gotoxy(2,1);
    cout << "\n  (1)Apilar"
            "\n  (2)Desapilar"
            "\n  (3)Mostrar tope"
            "\n  (4)Mostrar Pila"
            "\n  (5)Salir"<<endl;
    gotoxy(2,8);
    string mensaje="\nElige una opcion: \n";
    opc=validar(mensaje);
    cout<<"Se ha elegido un NUMERO valido\n"<<endl;
    return opc;
};

int main(){

    Nodo *pila = NULL;
    string value, cont;
    int opcion,cont2;
    do {
    switch(menu()){
        case 1:
            cout<<"Numero: ";
            cin>>cont;
            cont2++;
            push(pila, cont);
            cout<<"Se ha agredado un valor a la pila"<<endl;
            system("pause");
            system("cls");
            break;
        case 2:
            cont2--;
            pop(pila);
            cout<<"Se ha eliminado un valor de la pila"<<endl;
            system("pause");
            system("cls");
            break;
        case 3:
            peek(pila);
            system("cls");
            break;
        case 4:
            display(pila);
            system("cls");
            break;
        case 5: {cout<<"Haz elegido salir del programa"<<endl;
            string mensaje="\nSeguro que quieres salir?\n(1)Si   (2)No, quiero regresar\n";
            opcion=validar(mensaje);
            cout<<"El valor ingresado SI es un numero"<<endl;
            if (opcion==1){
                cout<<"Ahora si sales por completo del programa\nGracias por utilizar."<<endl;
                break;
                }
            if (opcion!=1){
                cout<<"Regresa al menu principal"<<endl;
                system("pause");
                system("cls");
                break;}}
    default: cout<<"Opcion incorrecta "<<endl;
            system("pause");
        }
    } while(opcion!=1);
};
/*
//Alan David Velez Gomez    INCO
#include <iostream>
#include <cstdlib>
#include<windows.h>

using namespace std;

//VALIDACION
bool entero(char *a);
char cadena[100];
void error(){
    cout<<"\nEste dato no es valido, intenta de nuevo..."<<endl;
}
int validar(string a){
    do{
        cout<<a;
        cin>>cadena;
        if(!entero(cadena)){
        error();
        }
      }while(!entero(cadena));
    return atoi(cadena);
}
bool entero(char *a){
    for(int i = 0; i<strlen(a); i++){
        if(!isdigit(a[i])){
            return false;
        }
    }
    return true;
}
//CLASE
class Nodo{
  public:
    int value;
    Nodo* next;
};

void push(Nodo *&pila, int n){
  Nodo *temp = new Nodo();
  temp->value = n;
  temp->next = pila;
  pila = temp;
};

void pop(Nodo *&pila){
  Nodo *temp = pila;
  pila = temp->next;
  delete(temp);
};

void gotoxy(int x,int y){
      HANDLE hcon;
      hcon = GetStdHandle(STD_OUTPUT_HANDLE);
      COORD dwPos;
      dwPos.X = x;
      dwPos.Y= y;
      SetConsoleCursorPosition(hcon,dwPos);
 }

void peek(Nodo *&pila){
    Nodo *temp = pila;
    int y=10;
    gotoxy(50,y++);
    printf("\t%c%c%c%c%c\n",201,205,205,205,187);
    gotoxy(48,y++);
    printf("TOPE -> %c ",186);
    cout<<temp->value; printf(" %c\n",186);
    gotoxy(50,y++);
    printf("\t%c%c%c%c%c\n",200,205,205,205,188);
    gotoxy(40,y++);
    system("pause");
}

void display(Nodo *&pila){
    Nodo *temp = pila;
    int i=5;
    while(temp!=NULL){
        if(temp==pila){
            gotoxy(50,i++);
            printf("\t%c%c%c%c%c\n",201,188,250,200,187);
            gotoxy(50,i++);
            printf("\t%c",186);
            cout <<" "<<temp->value<<" ";
            printf("%c\n",186);
            temp=temp->next;
        }else{
            gotoxy(50,i++);
            printf("\t%c%c%c%c%c\n",204,205,205,205,185);
            gotoxy(50,i++);
            printf("\t%c",186);
            cout <<" "<<temp->value<<" ";
            printf("%c\n",186);
            temp=temp->next;
        }
    }
    gotoxy(50,i++);
    printf("\t%c%c%c%c%c\n",200,205,205,205,188);
    gotoxy(40,i++);
    system("pause");
    cout << endl;
}

int menu(){
    int opc;
    gotoxy(2,1);
    cout << "\n  (1)Apilar"
            "\n  (2)Desapilar"
            "\n  (3)Mostrar tope"
            "\n  (4)Mostrar Pila"
            "\n  (5)Salir"<<endl;
    gotoxy(2,8);
    string mensaje="\nElige una opcion: \n";
    opc=validar(mensaje);
    cout<<"Se ha elegido un NUMERO valido\n"<<endl;
    return opc;
};

int main(){

    Nodo *pila = NULL;
    int value, cont=0, opcion;
    do {
    switch(menu()){
        case 1:
            cout<<"Numero: ";
            cin>>cont;
            push(pila, cont);
            cout<<"Se ha agredado un valor a la pila"<<endl;
            system("pause");
            system("cls");
            break;
        case 2:
            cont--;
            pop(pila);
            cout<<"Se ha eliminado un valor de la pila"<<endl;
            system("pause");
            system("cls");
            break;
        case 3:
            peek(pila);
            system("cls");
            break;
        case 4:
            display(pila);
            system("cls");
            break;
        case 5: {cout<<"Haz elegido salir del programa"<<endl;
            string mensaje="\nSeguro que quieres salir?\n(1)Si   (2)No, quiero regresar\n";
            opcion=validar(mensaje);
            cout<<"El valor ingresado SI es un numero"<<endl;
            if (opcion==1){
                cout<<"Ahora si sales por completo del programa\nGracias por utilizar."<<endl;
                break;
                }
            if (opcion!=1){
                cout<<"Regresa al menu principal"<<endl;
                system("pause");
                system("cls");
                break;}}
    default: cout<<"Opcion incorrecta "<<endl;
            system("pause");
        }
    } while(opcion!=1);
};
*/
