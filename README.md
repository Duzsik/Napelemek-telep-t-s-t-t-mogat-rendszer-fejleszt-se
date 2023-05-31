# Napelemek-telepiteset-tamogato-rendszer-fejlesztese

A README egy C# nyelven írt WPF alkalmazás dokumentációját tartalmazza. Az alkalmazás egy napelemes projektek kezelésére szolgáló szoftver. A következő részekből áll:

MainWindow.xaml.cs

- MainWindow osztály: Ez az osztály az alkalmazás főablakát definiálja és a Window osztályból származik. Az osztály konstruktorában inicializáljuk az ablakot.

- ShowPass_Checked metódus: Ez a metódus akkor fut le, ha a "Show Password" jelölőnégyzetet bekapcsolják. A jelszó mezőben megjeleníti a beírt szöveget.

- ShowPass_Unchecked metódus: Ez a metódus akkor fut le, ha a "Show Password" jelölőnégyzetet kikapcsolják. A jelszó mezőben megjeleníti a beírt szöveget.

- Button_Click metódus: Ez a metódus akkor fut le, ha a "Login" gombot megnyomják. Létrehoz egy Employee objektumot, beállítja a felhasználónevet és jelszót, majd létrehoz egy HttpClient objektumot. Az API végpontot a BaseAddress tulajdonságon keresztül állítjuk be. Ezután aszinkron módon elküldünk egy GET kérést az API végpontnak, amely a felhasználónevet és jelszót tartalmazza. Ha a válasz státuszkódja BadRequest (HTTP 400), akkor a felhasználónevet vagy jelszót hibásnak jelzi. Ellenkező esetben olvassa el a válasz tartalmát és alakítsa át az Employee objektummá. A felhasználó szerepétől függően megnyitja az adott ablakot és bezárja az aktuális ablakot.

- Grid_ContextMenuClosing metódus: Ez a metódus akkor fut le, ha a felhasználó bezárja a menüt.

- closeClick metódus: Ez a metódus akkor fut le, ha a felhasználó bezárja az alkalmazást. A Application.Current.Shutdown() metódussal leállítja az alkalmazást.

storageManager.xaml.cs

- A kód elején importálásra kerülnek a szükséges névterek és osztályok.

- ComponentStorage osztály: Ez az osztály tartalmazza a komponenst (Component osztály) és a raktárat (Storage osztály).

- storageManager osztály: Ez az osztály felelős a raktárkezelő ablak megjelenítéséért és a komponensek és foglalások betöltéséért. Az osztály konstruktora inicializálja az ablakot, betölti a komponenseket, és hozzárendeli az eseménykezelőket.

- exit metódus: Ez a metódus bezárja az aktuális ablakot és megjeleníti a főablakot.

- LoadComponent metódus: Ez a metódus aszinkron módon lekéri a komponenseket az API végpontból, majd a választ feldolgozza és megjeleníti a felhasználói felületen. Az elkészült komponensek listája megjelenik a warehouseGrid adatrácsban.

- LoadReservation metódus: Ez a metódus aszinkron módon lekéri a foglalásokat az API végpontból, majd a választ feldolgozza és megjeleníti a felhasználói felületen. Az elkészült foglalások listája megjelenik a warehouseGrid adatrácsban.

- addItem metódus: Ez a metódus új komponenst ad hozzá az adatbázishoz a felhasználó által megadott adatok alapján. A komponens neve, ára és maximális mennyisége kerül megadásra a megfelelő szövegmezőkön keresztül.

- changePrice_Quantity_Btn metódus: Ez a metódus megváltoztatja egy komponens árát és/vagy maximális mennyiségét a felhasználó által megadott értékek alapján. A módosításhoz a ProductComboBox mezőben kiválasztott komponens kerül felhasználásra.

- SetStorageClick metódus: Ez a metódus raktározási műveletet hajt végre a felhasználó által megadott adatok alapján. Az eljárás ellenőrzi, hogy a kiválasztott komponens maximális mennyisége nem haladja-e meg a megadott raktárhelyen a tárolható mennyiséget. Ha a mennyiség megfelelő, a komponens és a raktárhely információit tartalmazó objektumot elküldi az API végpontnak.

- lowQuantity metódus: Ez a metódus kiszűri és megjeleníti azokat a komponenseket, amelyeknél a mennyiség 5 vagy annál kevesebb.

- missingQuantity metódus: Ez a metódus kiszűri és megjeleníti azokat a komponenseket, amelyeknél a készletmennyiség kisebb, mint a foglalások száma.

- All metódus: Ez a metódus megjeleníti az összes komponenst a raktárban.

- refreshBtn metódus: Ez a metódus újra betölti a komponenseket az adatbázisból.

stockKeeper.xaml.cs
Metódusok:

- exit(): Ez a metódus bezárja az aktuális ablakot és megjeleníti a főablakot.

- stockKeeper(): Az osztály konstruktora, amely inicializálja az ablakot és meghívja a Load() metódust.

Metódusok részletesen:
- Load(): Ez a metódus aszinkron módon tölti be az ablakot. Létrehoz egy HttpClient objektumot, beállítja a BaseAddress-et a "https://localhost:7186/" címre. Törli a projectcmbbx és a FilterProject elemeket. Lekéri az API-n keresztül a projektlistát, majd feldolgozza a választ. A projektek listáját beállítja a ProjectDataGrid adatforrásként. Végigmegy a projektek listáján, és hozzáadja az elemeket a projectcmbbx és a FilterProject elemekhez.

- ChangeProjectStatus(object sender, RoutedEventArgs e): Ez a metódus aszinkron módon végzi a projekt státuszának változtatását. Létrehoz egy HttpClient objektumot, beállítja a BaseAddress-et a "https://localhost:7186/" címre. Kiolvassa a projectcmbbx kiválasztott elemét, majd lekéri az API-n keresztül a projekthez tartozó adatokat. Ha sikeres a kérés, feldolgozza a választ, majd elküldi a szükséges adatokat a megfelelő végpontokra.

- ProjectSelection(object sender, SelectionChangedEventArgs e): Ez a metódus aszinkron módon végzi a projekt kiválasztásának kezelését. Létrehoz egy HttpClient objektumot, beállítja a BaseAddress-et a "https://localhost:7186/" címre. Ellenőrzi, hogy van-e kiválasztott elem a FilterProject elemen. Ha van, lekéri az API-n keresztül a kiválasztott projekt adatait, majd feldolgozza a választ és frissíti a WorkerDataGrid adatforrást.

- refreshBtn(object sender, RoutedEventArgs e): Ez a metódus frissíti az ablakot a Load() metódus meghívásával.

professional.xaml.cs
- ProjectComponent osztály: Ez az osztály a projekt komponenseit reprezentálja, és tartalmazza a projektet (Project osztály), a komponenst (Component osztály) és a mennyiséget (qty) tulajdonságokat.

- professional osztály: Ez az osztály felelős a főablak megjelenítéséért és a projektek kezeléséért. Az osztály konstruktorában betölti a komponenseket és a projekteket, majd a felhasználói felületen megjeleníti őket.

- LoadCompontents metódus: Ez a metódus aszinkron módon lekéri a komponenseket egy API végpontból, majd a választ feldolgozza és megjeleníti a felhasználói felületen.

- LoadProjects metódus: Ez a metódus aszinkron módon lekéri a projekteket és a foglalásokat az API végpontokról, majd a választ feldolgozza és megjeleníti a felhasználói felületen.

- exit metódus: Ez a metódus bezárja a jelenlegi ablakot és megjeleníti a főablakot.

- Egyéb eseménykezelő metódusok: Az osztályban találhatók olyan metódusok, amelyek kezelik a különböző eseményeket, például gombnyomást vagy állapotváltozást.

A kódban gyakran találhatóak HttpClient objektumok, amelyek segítségével HTTP kéréseket küldenek az API végpontokra, majd a válaszokat feldolgozzák és megjelenítik a felhasználói felületen. Az alkalmazás az "https://localhost:7186/" alapcímen található API végpontokat használja a projektek és komponensek kezeléséhez.

Az alkalmazás fő funkciói közé tartozik a projektek és komponensek betöltése, új projektek és foglalások létrehozása, projektek státuszának módosítása, valamint az árak kiszámítása és megjelenítése.
