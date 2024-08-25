class Knjiga {
  final int id;
  final String naslov;
  final String? naslovnaSlika;
  final int autorId;
  final DateTime datumIzdavanja;
  final String? opis;
  final bool? dostupnost;
  final double? cijena;

  Knjiga({
    required this.id,
    required this.naslov,
    this.naslovnaSlika,
    required this.autorId,
    required this.datumIzdavanja,
    this.opis,
    this.dostupnost,
    this.cijena,
  });

  factory Knjiga.fromJson(Map<String, dynamic> json) {
    return Knjiga(
      id: json['idKnjiga'],
      naslov: json['naslov'],
      naslovnaSlika: json['naslovnaSlika'],
      autorId: json['autorId'],
      datumIzdavanja: DateTime.parse(json['datumIzdavanja']),
      opis: json['opis'],
      dostupnost: json['dostupnost'],
      cijena: json['cijena']?.toDouble(),
    );
  }
}
