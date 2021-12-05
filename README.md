Projekat iz Platformi za objektno programiranje 2021/2022

Potrebno je realizovati stand-alone GUI .NET aplikaciju u WPF tehnologiji za pregled i rezervisanje individualnih treninga u fitnes centru.

Aplikacija ima sledeće entitete:

1. Adresa – šifra, ulica, broj, grad, država
2. Fitnes centar – šifra, naziv centra i adresa na kojoj se nalazi
3. Registrovani korisnik - ime, prezime, JMBG (jedinstven), pol, adresa, email, lozinka, tip registrovanog korisnika (registrovani korisnici mogu biti administratori, polaznici i instruktori).
4. Instruktor - registrovani korisnik, lista Treninga (pregled rezervisanih/slobodnih)
5. Polaznik - registrovani korisnik, lista rezervisanih Treninga
6. Trening - šifra (jedinstvena), datum treninga, vreme početka treninga, trajanje treninga (izraženo u minutima), status treninga (Slobodan, rezervisan), Instruktor kod kog je trening zakazan i Polaznik koji je zakazao trening. Napomena: Svaki instruktor ima svoj spisak mogućih treninga i trening postoji i ako je u statusu SLOBODAN.

Sve šifre u sistemu moraju biti jedinstvene.

Aplikaciju mogu da koriste i registrovani i neregistrovani korisnici. Registrovani korisnici su administratori, instruktori i polaznici.

Perzistenciju podataka realizovati korišćenjem relacione baze podataka.

Aplikacija podržava sledeće funkcionalnosti:

1. {+ Neregistrovani korisnik ima mogućnost pregleda osnovnih informacija o fitnes centru i o instruktorima koji rade u njemu. Nema mogućnost zakazivanja treninga. +}

2. {+ Omogućiti neregistrovanim korisnicima (polaznicima) mogućnost registracije na sistem. Prilikom registracije unose se - ime, prezime, JMBG (jedinstven), pol, adresa, email, lozinka. Za novog korisnika se automatski formira prazna lista treninga (lista podrazumeva prikaz svih treninga koje je polaznik rezervisao) +}.

3. {+ Omogućiti registrovanim korisnicima da se prijave i odjave sa sistema. Prilikom prijave na sistem korisnik unosi JMBG i lozinku sa kojima se registrovao. +}

4. {+ Svi registrovani korisnici imaju pregled svojih ličnih podataka i mogućnost izmene istih. +}

5. Administrator-ima mogućnost pregleda svih entiteta. Sve podatke može da doda, izmeni i obriše. Sva brisanja su logička (podatak postaje neaktivan i više se ne prikazuje, ne može se obrisati i izmeniti). Može da briše Treninge bez obzira da li su REZERVISANI ili SLOBODNI. Kreira inicijalno SLOBODNE treninge instruktorima. Samo administratori mogu da registruju nove instruktore.

6. Instruktor ima mogućnost pregleda svojih treninga (slobodnih i zauzetih) za odabrani datum i pregled polaznika koji su kod njega rezervisali trening. Omogućiti da instruktori kreiraju i brišu
svoje slobodne treninge. Ograničenje prilikom brisanja termina: instruktor ne može da obriše trening ako je REZERVISAN tj. ako je u tom terminu izvršena rezervacija.

7. Polaznik ima mogućnost da za odabranog instruktura pregleda listu slobodnih/rezervisanih treninga. Omogućiti grafički prikaz svih treninga (REZERVISANIH/SLOBODNIH) za odabranog instruktora. Polaznik ima mogućnost rezervacije SLOBODNOG treninga, kao i otkazivanja svog prethodno REZERVISANOG treninga.

8. Pretraga je realizovana tako da korisnici imaju pregled sledećih entiteta:
	{+ * Instruktora - pretraga po imenu, prezimenu, adresi, email adresi (ovu mogućnost imaju REGISTROVANI/NEREGISTROVANI koriscnici sistema) +}
	* Registrovani korisnici- pretraga po imenu, prezimenu, adresi, email adresi, ili po tipu (ovu mogućnost imaju administratori)

9. {+ Prilikom pretrage omogućiti sortiranje entiteta po imenu i prezimenu, u opdajućem,i/ili rastućem redosledu. +}