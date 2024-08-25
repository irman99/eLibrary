class Korisnik {
  final int idKorisnik;
  final String ime;
  final String prezime;
  final String? email;  // Nullable
  final String? korisnickoIme;  // Nullable
  final String? fotografija;  // Nullable
  final DateTime datumRodjenja;
  final int? tipKorisnika;  // Nullable

  Korisnik({
    required this.idKorisnik,
    required this.ime,
    required this.prezime,
    this.email,
    this.korisnickoIme,
    this.fotografija,
    required this.datumRodjenja,
    this.tipKorisnika,
  });

  factory Korisnik.fromJson(Map<String, dynamic> json) {
    return Korisnik(
      idKorisnik: json['idKorisnik'],
      ime: json['ime'],
      prezime: json['prezime'],
      email: json['email'],
      korisnickoIme: json['korisnickoIme'],
      fotografija: json['fotografija'],
      datumRodjenja: DateTime.parse(json['datumRodjenja']),
      tipKorisnika: json['tipKorisnika'],
    );
  }
}
