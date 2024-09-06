import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart'; // Import SharedPreferences
import '../models/korisnik.dart';

const String baseUrl = 'https://localhost:7189';

class ApiService {
  // Method to fetch Korisnik by ID
  Future<Korisnik> fetchKorisnikById(int id) async {
    final prefs = await SharedPreferences.getInstance();
    final token = prefs.getString('auth_token') ?? '';

    final response = await http.get(
      Uri.parse('$baseUrl/Korisnik/GetKorisnik?IdKorisnik=$id'),
      headers: {
        'Authorization': 'Bearer $token', // Ensure this is included
      },
    );

    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      return Korisnik.fromJson(data);
    } else {
      throw Exception('Failed to load Korisnik');
    }
  }

  // Method to log in a user and store the token
  Future<void> loginUser({
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
      final token = decoded['token'] as String; // Extract token from response

      // Store the token using SharedPreferences
      final prefs = await SharedPreferences.getInstance();
      await prefs.setString('auth_token', token);

      print('Login successful. Token stored.');
    } else {
      throw Exception('Failed to login: ${response.body}');
    }
  }

  // Method to register a new user
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

  // Method to fetch the current user's info
  Future<Korisnik> getUserInfo() async {
    final prefs = await SharedPreferences.getInstance();
    final token = prefs.getString('auth_token') ?? '';

    final response = await http.get(
      Uri.parse('$baseUrl/Auth/Me'), // Endpoint for user info
      headers: {
        'Authorization': 'Bearer $token', // Include token in header
      },
    );

    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      return Korisnik.fromJson(data);
    } else {
      throw Exception('Failed to fetch user info');
    }
  }
}
