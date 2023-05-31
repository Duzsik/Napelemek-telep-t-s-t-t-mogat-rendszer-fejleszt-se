# Napelemek-telepiteset-tamogato-rendszer-fejlesztese

A README egy C# nyelven írt WPF alkalmazás dokumentációját tartalmazza. Az alkalmazás egy napelemes projektek kezelésére szolgáló szoftver. A következő részekből áll:

MainWindow.xaml.cs
Metódusok:
-MainWindow(): Az osztály konstruktora, amely inicializálja az ablakot.

Metódusok részletesen:
- ShowPass_Checked: Ez a metódus a jelszó megjelenítésének kezelését végzi. Amikor a "ShowPass" jelölőnégyzet be van pipálva, a jelszó szövegmező tartalmát beállítja a jelszóvédett mező értékére, majd a jelszóvédett mezőt elrejti (Visibility.Collapsed) és a szövegmezőt megjeleníti (Visibility.Visible).

- ShowPass_Unchecked: Ez a metódus a jelszó elrejtésének kezelését végzi. Amikor a "ShowPass" jelölőnégyzet nincs bepipálva, a jelszóvédett mező értékét beállítja a szövegmező tartalmára, majd a szövegmezőt elrejti (Visibility.Collapsed) és a jelszóvédett mezőt megjeleníti (Visibility.Visible).

- Button_Click: Ez a metódus végzi a bejelentkezés gombra kattintás kezelését. Létrehoz egy Employee objektumot a felhasználónév és jelszó mezők tartalmával. Létrehoz egy HttpClient objektumot, beállítja a BaseAddress-et a "https://localhost:7186/" címre. Kér egy HTTP GET kérést az API-hoz, hogy ellenőrizze a felhasználónevét és jelszavát. A válasz alapján megjeleníti az adott felhasználó szerepének megfelelő ablakot.

- Grid_ContextMenuClosing: Ez a metódus üres metódus, nem csinál semmit. Az eseménykezelő az ablak kontextusmenü bezárását kezeli.

- closeClick: Ez a metódus kezeli az ablak bezárását. Az alkalmazást leállítja (Application.Current.Shutdown()).

professional.xaml.cs
- Az alkalmazás Napelem névtérben található, és tartalmazza az alkalmazás főosztályát, a professional osztályt, amely a Window osztályból származik. Az Interaction logic for professional.xaml komment jelzi, hogy az osztály az alkalmazás "professional" felhasználói felületét kezeli.

- Az Employee osztályhoz hasonlóan az ProjectComponent osztály az adatok tárolására szolgál, amelyek a projekt és a komponensek közötti kapcsolatot reprezentálják. Az Employee osztályban található project, component és qty tulajdonságok.

- Az exit() metódus egy új MainWindow objektumot hoz létre, majd bezárja a jelenlegi ablakot és megjeleníti az új ablakot. Ez a metódus a kilépés funkciót valósítja meg az alkalmazásban.

- Az professional osztály konstruktora inicializálja az osztályt, betölti a komponenseket és a projekteket, és beállítja az emp adattagot.

- A LoadComponents() metódus aszinkron módon lekéri a komponenseket a szerverről. Egy HTTP kérésben elküldi a GET kérést a api/Component/SendComponent végpontra. Ha a kérés eredményes volt, az adatokat JSON formátumban kapja vissza, majd a választ feldolgozza és betölti a komponenseket az assetSelectComboBox és assetGrid vezérlőkbe.

- A LoadProjects() metódus betölti a projekteket és a foglalásokat az alkalmazásba. Először lekéri a projekteket a szerverről egy HTTP GET kéréssel a api/Project/ListProjects végponton keresztül. Ha a válasz sikeres volt, feldeldolgozza a választ és betölti az adatokat a projectGrid vezérlőbe.

- A loadEmployee() metódus lekéri a dolgozók adatait a szerverről egy HTTP GET kéréssel a api/Employee/GetEmployees végponton keresztül. Ha a válasz sikeres volt, az adatokat JSON formátumban kapja vissza, majd feldolgozza és betölti az adatokat a emp adattagba.

- Az addButton_Click metódus kezeli a "Hozzáadás" gombra kattintást. Először megnézi, hogy van-e kiválasztott projekt és komponens. Ha igen, akkor ellenőrzi a mennyiséget, majd létrehoz egy új ProjectComponent objektumot a kiválasztott adatokkal. Hozzáadja ezt az objektumot az emp adattaghoz és frissíti a empGrid vezérlőt.

- Az removeButton_Click metódus kezeli a "Törlés" gombra kattintást. Ellenőrzi, hogy van-e kiválasztott elem a empGrid-ben. Ha igen, akkor eltávolítja az adott elemet az emp adattagból és frissíti a empGrid vezérlőt.

- Az exitButton_Click metódus kezeli a "Kilépés" gombra kattintást. Meghívja a exit() metódust, amely bezárja az aktuális ablakot és megjeleníti a fő ablakot.

- Az alkalmazás a professional.xaml fájlban definiálja a felhasználói felületet, amely tartalmazza a különböző vezérlőket, például a assetSelectComboBox, assetGrid, projectGrid, empGrid stb. Ezeket a vezérlőket az x:Name attribútum segítségével lehet elérni a kódban.

storageManager.xaml.cs
- Az osztály első része a ComponentStorage osztályt tartalmazza, amely két tulajdonságot definiál: Component és Storage. Ez a két tulajdonság tárolja az alkatrész és raktárhely információit.

- Ezután következik maga a storageManager osztály, amely a Window osztályból származik. Az osztályban találhatóak a különböző metódusok és eseménykezelők, amelyek a felhasználói felület működését és interakcióit kezelik.

- A storageManager osztályban található néhány fontos metódus:

- exit(): Ez a metódus létrehoz egy MainWindow példányt, bezárja az aktuális ablakot (storageManager), majd megjeleníti a fő ablakot (MainWindow).

- LoadComponent(): Ez a metódus lekéri a komponensek adatait a szerverről egy HTTP GET kéréssel a api/Component/SendComponent végponton keresztül. Ha a válasz sikeres volt, a választ JSON formátumban kapja vissza, majd feldolgozza és betölti az adatokat a IntakeProductComboBox és ProductComboBox vezérlőkbe. A komponensek listáját hozzárendeli a warehouseGrid vezérlőhöz.

- LoadReservation(): Ez a metódus lekéri a foglalások adatait a szerverről egy HTTP GET kéréssel a api/Reservation/ListReservation végponton keresztül. Ha a válasz sikeres volt, a választ JSON formátumban kapja vissza, majd feldolgozza és betölti az adatokat a warehouseGrid vezérlőbe.

- storageManager() konstruktor: Ez a konstruktor inicializálja az osztályt. Meghívja a InitializeComponent() metódust, amely inicializálja a felhasználói felületet. Ezután meghívja a LoadComponent() metódust a komponensek betöltéséhez. Végül hozzárendeli az ablak bezárásának eseményét a Closing eseménykezelőhöz.

- mainExitBtn_Click(): Ez az eseménykezelő reagál a mainExitBtn gombra kattintásra. Hívja a exit() metódust a kilépéshez.

- addItem(): Ez az eseménykezelő reagál az addItem gombra kattintásra. Létrehoz egy HttpClient példányt, és beállítja a kiszolgáló alapcímét. Ezután létrehoz egy új Component példányt az adatokkal, amelyeket a felhasználó megadott a megfelelő szövegdobozokban. A komponens adatait JSON formátumba alakítja, majd egy HTTP POST kéréssel elküldi a api/Component/AddComponent végpontra. A választ feldolgozza, és megjelenít egy üzenetet a felhasználónak.

- changePrice_Quantity_Btn(): Ez az eseménykezelő reagál a changePrice_Quantity_Btn gombra kattintásra. Létrehoz egy HttpClient példányt, és beállítja a kiszolgáló alapcímét. A felhasználó által kiválasztott komponens adatait beolvassa a ProductComboBox szövegdobozból. A megadott új árat vagy mennyiséget beállítja a komponensben, majd JSON formátumba alakítja és elküldi egy HTTP POST kéréssel a megfelelő végpontra (api/Component/ChangeMaxQuantity vagy api/Component/ChangePrice). A választ feldolgozza, és megjelenít egy üzenetet a felhasználónak.

- SetStorageClick(): Ez az eseménykezelő reagál a SetStorageClick gombra kattintásra. Létrehoz egy HttpClient példányt, és beállítja a kiszolgáló alapcímét. A felhasználó által kiválasztott komponens azonosítóját beolvassa a IntakeProductComboBox szövegdobozból. Lekéri a komponensek adatait egy HTTP GET kéréssel a api/Component/SendComponent végponton keresztül. Ha a válasz sikeres volt, feldolgozza a választ, és megtalálja a kiválasztott komponenst. Ellenőrzi, hogy a megadott mennyiség nem haladja-e meg a maximális mennyiséget, majd létrehoz egy Storage és ComponentStorage példányt az adatokkal. Az adatokat JSON formátumba alakítja, majd elküldi egy HTTP POST kéréssel a api/Storage/AddComponentToStorage végpontra. A választ feldolgozza, és megjelenít egy üzenetet a felhasználónak.

- lowQuantity(): Ez az eseménykezelő reagál a lowQuantity gombra kattintásra. Létrehoz egy HttpClient példányt, és beállítja a kiszolgáló alapcímét. Lekéri a komponensek adatait egy HTTP GET kéréssel a api/Component/SendComponent végponton keresztül. Ha a válasz sikeres volt, feldolgozza a választ, és a komponenseket ellenőrzi, hogy a mennyiségük 5 vagy annál kevesebb-e. Az eredményt egy új listában tárolja, majd ezt a listát jeleníti meg a warehouseGrid adatrácsban.

- missingQuantity(): Ez az eseménykezelő reagál a missingQuantity gombra kattintásra. Létrehoz egy HttpClient példányt, és beállítja a kiszolgáló alapcímét. Lekéri a foglalások adatait egy HTTP GET kéréssel a api/Reservation/ListReservation végponton keresztül. Ha a válasz sikeres volt, feldolgozza a választ, és a foglalásokat tárolja egy listában. Ezután újra lekéri a komponensek adatait egy HTTP GET kéréssel a api/Component/SendComponent végponton keresztül. Ha a válasz sikeres volt, feldolgozza a választ, és a komponensek és a foglalások alapján ellenőrzi, hogy mely komponensek hiányoznak a foglalásokhoz képest. Az eredményt egy új listában tárolja, majd ezt a listát jeleníti meg a warehouseGrid adatrácsban.

- All(): Ez az eseménykezelő reagál az All gombra kattintásra. Létrehoz egy HttpClient példányt, és beállítja a kiszolgáló alapcímét. Lekéri a komponensek adatait egy HTTP GET kéréssel a api/Component/SendComponent végponton keresztül. Ha a válasz sikeres volt, feldolgozza a választ, és a komponenseket jeleníti meg a warehouseGrid adatrácsban.

- refreshBtn(): Ez az eseménykezelő reagál a refreshBtn gombra kattintásra. Hívja a LoadComponent() metódust, amely újra betölti a komponensek adatait a warehouseGrid adatrácsba.

stockKeeper.xaml.cs
- exit(): Ez a metódus egy új MainWindow objektumot hoz létre, bezárja az aktuális ablakot, majd megjeleníti az új MainWindow-t.

- stockKeeper(): Ez a konstruktor inicializálja az ablakot (InitializeComponent()), majd meghívja a Load() metódust.

- Load(): Ez az aszinkron metódus a HttpClient osztályt használva HTTP kérést küld az alkalmazás szerverének, hogy lekérje a projektek listáját. A válasz JSON formátumban érkezik, amelyet a JsonConvert osztály segítségével feldolgoz és deszerializál a List<Project> típusba. A projektek listáját beállítja a ProjectDataGrid adatforrásául, valamint a projectcmbbx és a FilterProject ComboBox elemeket feltölti a projektek adataival.

- back(): Ez az eseménykezelő metódus hívódik meg, amikor a "back" gombot megnyomják. Bezárja az aktuális ablakot és megjeleníti a MainWindow-t.

- ReservationsAndProjectId: Ez egy belső osztály, amely egy projekthez és a hozzá tartozó foglalásokhoz kapcsolódó adatokat tárolja.

- ChangeProjectStatus(): Ez az aszinkron metódus hívódik meg, amikor a "Change Status" gombot megnyomják. A HttpClient osztály segítségével HTTP kérést küld az alkalmazás szerverének, hogy lekérje a kiválasztott projekt adatait. A válasz JSON formátumban érkezik, amelyet a JsonConvert osztály segítségével deszerializál a Project típusba. Ezután újabb HTTP kérést küld a foglalások lekérdezésére, majd a válasz alapján módosítja a projekt státuszát, és további műveleteket végez a log és a státusz mentésére.

- ProjectSelection(): Ez az eseménykezelő metódus hívódik meg, amikor a FilterProject ComboBox kiválasztása megváltozik. A kiválasztott projekt alapján lekérdezi a hozzá tartozó foglalásokat, majd a WorkerDataGrid adatforrásaként beállítja azokat.

- refreshBtn(): Ez az eseménykezelő metódus hívódik meg, amikor a "Refresh" gombot megnyomják. Újra betölti az alkalmazás projekt adatait a Load() metódus segítségével.
