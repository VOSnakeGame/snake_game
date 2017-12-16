# snake_game

Datum predaje: 22. 12. 2017.

---

IMPORTANT!

Asseti kao libovi sa unity store-a, koristeni u igri, se nalaze na Google drive-u radi velicine asseta
https://drive.google.com/drive/folders/1Vz97_cP-qaldG9SIm-fL5eSaKs-WDgbE?usp=sharing

Potrebno je kopirati lib folder cijeli u unity projekt -> Assets/lib

---

Potrebno napraviti jos:
	- Modeli za sarmu
	- Modeli za enemije
	- Ispraviti bugove:
		- na sceni 2, 3, 4 ne rade game over gumbi -> u Project Hierarchy se moze naci pod GameManager imenom kao i u prefabs
			skripta ManageGame handla gumbe, dok player u OnCollisionEnter zove metode iz ManageGame
		- kad se pokrene sama igra kao .exe gumbi su potrgani na prvom ekranu, Play izlazi iz igre a quit ne radi nista, u projektu rade normalno