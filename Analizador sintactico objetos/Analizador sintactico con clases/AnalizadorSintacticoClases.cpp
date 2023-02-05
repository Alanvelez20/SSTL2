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
class ElementoPila{
  public:
    string value;
    ElementoPila* next;
};

void push(ElementoPila *&pila, string n){
  ElementoPila *temp = new ElementoPila();
  temp->value = n;
  temp->next = pila;
  pila = temp;
};

void pop(ElementoPila *&pila){
  ElementoPila *temp = pila;
  pila = temp->next;
  delete(temp);
};

void display(ElementoPila *&pila){
    ElementoPila *temp = pila;
    int i=5;
    while(temp!=NULL){
        if(temp==pila){
            cout <<"Tope-> "<<temp->value<<" - ";
            temp=temp->next;
        }else{
            cout <<""<<temp->value<<" - ";
            temp=temp->next;
        }
    }
    cout<<endl<<endl;
    system("pause");
    cout << endl;
}

int menu(){
    int opc;
    cout << "\n  (1)Apilar"
            "\n  (2)Desapilar"
            "\n  (3)Salir"<<endl;
    string mensaje="\nElige una opcion: \n";
    opc=validar(mensaje);
    cout<<"Se ha elegido un valor valido\n"<<endl;
    return opc;
};

int main(){

    ElementoPila *pila = NULL;
    string value, cont;
    int opcion,cont2;
    do {
    switch(menu()){
        case 1:
            cout<<"Valor: ";
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
            display(pila);
            system("cls");
            break;
        case 4: {cout<<"Haz elegido salir del programa"<<endl;
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
