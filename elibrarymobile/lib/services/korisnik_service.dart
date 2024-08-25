import 'dart:convert';
import 'package:http/http.dart' as http;
import '../models/korisnik.dart';

const String baseUrl = 'https://localhost:7189';

class ApiService {
  // Method to fetch Korisnik by ID
  Future<Korisnik> fetchKorisnikById(int id) async {
    final response = await http.get(Uri.parse('$baseUrl/Korisnik/GetKorisnik?IdKorisnik=$id'));

    if (response.statusCode == 200) {
      final data = json.decode(response.body);

      return Korisnik.fromJson(data);
    } else {
      throw Exception('Failed to load Korisnik');
    }
  }



  Future<String> loginUser({
    required String korisnickoIme,
    required String lozinka,
  }) async {
    final url = Uri.parse('$baseUrl/Korisnik/LoginKorisnik');
    final response = await http.post(
      url,
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      },
      body: json.encode({
        'korisnickoIme': korisnickoIme,
        'lozinka': lozinka,
      }),
    );

    if (response.statusCode == 200) {
      final decoded = json.decode(response.body);
      return decoded['message'];
    } else {
      throw Exception('Failed to login: ${response.body}');
    }
  }


  Future<String> registerUser({
    required String ime,
    required String prezime,
    required String email,
    required String korisnickoIme,
    required String lozinka,
    required DateTime datumRodjenja,
    int tipKorisnika = 3, // default value
  }) async {
    final url = Uri.parse('$baseUrl/Korisnik/RegisterKorisnik');
    final response = await http.post(
      url,
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      },
      body: json.encode({
        'ime': ime,
        'prezime': prezime,
        'email': email,
        'korisnickoIme': korisnickoIme,
        'lozinka': lozinka,
        'datumRodjenja': datumRodjenja.toIso8601String(),
        'tipKorisnika': tipKorisnika,
      }),
    );

    if (response.statusCode == 200) {
      final decoded = json.decode(response.body);
      return decoded['message'];
    } else {
      throw Exception('Failed to register user: ${response.body}');
    }
  }
}
