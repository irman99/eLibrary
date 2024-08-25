import 'dart:convert';
import 'package:elibrarymobile/models/knjiga.dart';
import 'package:http/http.dart' as http;

const String baseUrl = 'https://localhost:7189';

class KnjigaService {
  Future<List<Knjiga>> fetchKnjige({
    String? naslov,
    String? datumIzdavanja,
    double? minPrice,
    double? maxPrice,
  }) async {
    final queryParams = <String, String>{};
    if (naslov != null && naslov.isNotEmpty) {
      queryParams['Naslov'] = naslov;
    }
    if (datumIzdavanja != null) {
      queryParams['DatumIzdavanja'] = datumIzdavanja;
    }
    if (minPrice != null) {
      queryParams['MinPrice'] = minPrice.toString();
    }
    if (maxPrice != null) {
      queryParams['MaxPrice'] = maxPrice.toString();
    }

    final uri = Uri.https('localhost:7189', '/Knjiga/GetKnjige', queryParams);
    final response = await http.get(uri);

    if (response.statusCode == 200) {
      final List<dynamic> data = json.decode(response.body);
      return data.map((json) => Knjiga.fromJson(json)).toList();
    } else {
      throw Exception('Failed to load knjige');
    }
  }

  Future<Knjiga> fetchKnjigaById(int id) async {
    final response = await http.get(Uri.parse('$baseUrl/Knjiga/GetKnjige?IdKnjiga=$id'));

    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      if (data is List<dynamic> && data.isNotEmpty) {
        return Knjiga.fromJson(data[0] as Map<String, dynamic>);
      } else {
        throw Exception('Expected a list with at least one Knjiga object');
      }
    } else {
      throw Exception('Failed to load knjiga');
    }
  }
}
