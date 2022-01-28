# Shop-Project 
**Aby uruchomić projekt należynwejść w appsettings.json i tam w connection string default zmienić Data Source na Pańską nazwę serwera oraz zrobić "update-database"**\
Projekt posiada rejestrację oraz logowanie, aby się zalogować jako admin należy podać:\
Login: Tomek\
Hasło: Klaudia123!

Jeśli jest się zalogowanym jako admin pokazuje się dostęp do panelu zarządzania, z którego można wykonywać takie akcje jak:\
-Zarządzanie produktami(Dodawanie, edytowanie, usuwanie oraz opis produktu),\
-Zarządzanie kategoriami produktów(dodawanie, edytowanie oraz usuwanie kategorii),\
-Zarządzanie kategoriami produktów(dodawanie produktu do określonych kategorii),\
-Zrządzanie użytkownikami(Edytowanie oraz usuwanie użytkowników),\
-Zarządzanie rolami(dodawnie, edytowanie oraz usuwanie ról),\
-Zarządzanie użytkownikami w rolach(dodawanie, edytowanie oraz usuwanie użytkowników z określonej roli),\
-Każdy zarejestrowany użytkownik może dodawać produkty do koszyka oraz je usuwać.

### Aplikacja posiada również Api REST

**ApiAdmministrator:**\
-FindUser(Wyszukuje użytkownika poprzez podanie jego id): ApiAdministrator/FindUser/ -należy podać id użytkownika\
-FindUsers(Wyszukuje wszystkich zarejestrowanych użytkowników): ApiAdministrator/FindUsers\
-EditUser(Wyszukuje użytkownika poprzez podanie jego id i edytuje podane dane): ApiAdministrator/EditUser\
{\
    "id": "",\
    "userName": ""\
}\
-DeleteUser(Wyszukuje użytkownika poprzez podanie jego id i usuwa): ApiAdministrator/DeleteUser/ -należy podać id użytkownika\
-FindRoles(Wyszukuje wszystkie dodane role): ApiAdministrator/FindRoles\
-AddRole(Dodaje role): ApiAdministrator/AddRole\
{\
    "RoleName": ""\
}\
-UserInRole(Wyszukuje uzytkownika w roli): ApiAdministrator/UserInRole/ -należy podać id użytkownika\
-EditRole(Wyszukuje role poprzez podanie jej id i edytuje podane dane): ApiAdministrator/EditRole\
{\
    "Id": "",\
    "RoleName": ""\
}\
-DeleteRole(Wyszukuje role poprzez podanie jej id i usuwa): ApiAdministrator/DeleteRole/ -należy podać id roli

**ApiAccount:**\
-Register(Rejestruje użytkownika): ApiAccount/Register\
{\
    "Login": "",\
    "Password": "",\
    "ConfirmPassword": ""\
}\
-Login(Loguje użytkownika): ApiAccount/Login\
{\
    "Login": "",\
    "Password": ""\
}\
-Logout(Wylogowywuje użytkownika): ApiAccount/Logout

**ApiShop:**\
-FindProduct(Wyszukuje produkt poprzez podanie jego id): ApiShop/FindProduct/ -należy podać id produktu\
-FindAllProducts(Wyszukuje wszystkie produkty): ApiShop/FindProducts\
-AddProduct(Dodaje produkt): ApiShop/AddProduct\
{\
    "Name": "",\
    "Description": "",\
    "Price": "",\
    "Amount": ""\
}\
-DeleteProduct(Wyszukuje produkt poprzez podanie jego id i usuwa): ApiShop/DeleteProduct/ -należy podać id produktu\
-EditProduct(Wyszukuje produkt poprzez podanie jego id i edytuje podane dane): ApiShop/EditProduct\
{\
    "Id": "",\
    "Name": "",\
    "Description": "",\
    "Price": "",\
    "Amount": ""\
}\
-FindCategory(Wyszukuje kategorie poprzez podanie jej id): ApiShop/FindCategory/ -należy podać id kategorii\
-FindAllCategories(Wyszukuje wszystkie kategorie): ApiShop/FindCategories\
-AddCategory(Dodaje kategorie): ApiShop/AddCategory\
{\
    "Name": ""\
}\
-DeleteCategory(Wyszukuje kategorie poprzez podanie jej id i usuwa): ApiShop/DeleteCategory/ -należy podać id kategorii\
-EditCategory(Wyszukuje katagorie poprzez podanie jej id i edutuje podane dane): ApiShop/EditCategory\
{\
    "Id": "",\
    "Name": ""\
}
