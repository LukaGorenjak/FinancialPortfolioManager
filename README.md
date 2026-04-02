# Financial Portfolio Manager

Namizna aplikacija za upravljanje finančnega portfelja, razvita v jeziku C# z ogrodjem Windows Forms (.NET 8). Aplikacija omogoča sledenje delniških in kriptovalutnih naložb, upravljanje gotovine ter pregled transakcij.

---

## Opis teme

Financial Portfolio Manager je aplikacija, ki uporabniku omogoča:

- vodenje portfelja z delnicami, kriptovalutami in gotovino,
- nakup in prodajo naložb z avtomatskim odbitkom oziroma dopisom gotovine,
- sledenje zgodovini transakcij (nakupi in prodaje),
- vnos metapodatkov naložb (borza, sektor, dividendni donos za delnice; veriga blokov, donos stakanja za kriptovalute),
- prikaz porazdelitve portfelja po vrstah naložb v odstotkih,
- preklop valute med EUR in USD,
- preklop med svetlim in temnim načinom prikaza.

---

## Namestitev in zagon

### Zahteve

- [Visual Studio 2022](https://visualstudio.microsoft.com/) ali novejši (Community zadostuje)
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (vključen v Visual Studio pri namestitvi komponente *.NET desktop development*)
- Operacijski sistem Windows 10 ali novejši

### Koraki

1. **Klonirajte repozitorij** z GitHuba:
   ```
   git clone https://github.com/<uporabniško-ime>/FinancialPortfolioManager.git
   ```
   ali prenesite ZIP arhiv in ga razpakirajte.

2. **Odprite rešitev** v Visual Studiu:
   - Dvokliknite datoteko `FinancialPortfolioManager.sln` v korenski mapi repozitorija,
   - ali v Visual Studiu izberite *File → Open → Project/Solution* in poiščite to datoteko.

3. **Zaženite aplikacijo**:
   - Pritisnite **F5** (zagon z razhroščevanjem) ali **Ctrl+F5** (zagon brez razhroščevanja).
   - Visual Studio bo samodejno prenesel potrebne pakete NuGet in prevedel projekt.

> Dodatnih namestitev ali ročnih sprememb ni potrebno.

---

## Navodila za uporabo

### Začetno stanje

Ob zagonu je v portfelju samodejno na voljo **1.000 EUR gotovine**.

---

### Polog in dvig gotovine

1. V spodnjem delu okna (razdelek *Portfolio*) nastavite željeni znesek v polju z vrtljivimi gumbi.
2. Kliknite **Deposit** za polog ali **Withdraw** za dvig.
3. Če pri dvigu ni dovolj sredstev, se prikaže opozorilo.

---

### Nakup naložbe

1. V razdelku *Trade* izberite vrsto naložbe v spustnem meniju (**Stock** ali **Crypto**).
2. Vnesite:
   - **Ticker** — simbol naložbe (npr. `AAPL`, `BTC`)
   - **Name** — polno ime naložbe (npr. `Apple Inc.`)
   - **Price** — nakupna cena na enoto
   - **Amount** — količina enot (najmanj 0,01)
3. *(Neobvezno)* Kliknite **Details** za vnos dodatnih podatkov:
   - Za delnico: borza, sektor, ali gre za ETF, dividendni donos (v %)
   - Za kriptovaluto: veriga blokov, ali gre za stablecoin, donos stakanja (v %)
4. Kliknite **Buy**.
   - Strošek nakupa se samodejno odšteje od gotovine.
   - Naložba se pojavi v seznamu *Investments*.
   - Transakcija se zabeleži v seznam *Transactions*.
   - Če imate že naložbo z istim simbolom in tipom, se količini samodejno združita z izračunom tehtane povprečne cene.

---

### Prodaja naložbe

1. Izberite vrsto naložbe in vnesite **Ticker**, **Name** in prodajno **Price**.
2. V polje **Amount** vnesite količino, ki jo želite prodati (največ toliko, kolikor imate v lasti).
3. Kliknite **Sell**.
   - Iztržek se samodejno doda k gotovini.
   - Če prodate celotno količino, se naložba odstrani iz seznama.

---

### Pregled portfelja

- **Skupna vrednost** portfelja se prikazuje v zgornjem delu okna in se samodejno osvežuje.
- **Porazdelitev** (delnice / kripto / gotovina v %) je prikazana pod skupno vrednostjo.
- Seznam **Investments** prikazuje stanje gotovine in vse naložbe s simbolom, količino in povprečno nakupno ceno.
- Seznam **Transactions** prikazuje celotno zgodovino nakupov in prodaj z datumom, simbolom, količino, ceno in skupno vrednostjo.

---

### Dodatne funkcije

| Gumb | Opis |
|---|---|
| **EUR / USD** | Preklopi prikaz valute med EUR in USD |
| **Dark Mode** | Preklopi med svetlim in temnim videzom aplikacije |
