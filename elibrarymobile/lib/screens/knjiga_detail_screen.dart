import 'package:flutter/material.dart';
import '../models/knjiga.dart';
import '../models/korisnik.dart';
import '../services/knjiga_service.dart';
import '../services/korisnik_service.dart';
import 'korisnik_detail_screen.dart'; // Import the new screen

class KnjigaDetailScreen extends StatefulWidget {
  final int knjigaId;

  const KnjigaDetailScreen({super.key, required this.knjigaId});

  @override
  _KnjigaDetailScreenState createState() => _KnjigaDetailScreenState();
}

class _KnjigaDetailScreenState extends State<KnjigaDetailScreen> {
  late Future<Knjiga> _knjigaFuture;
  late Future<Korisnik?> _authorFuture;
  final KnjigaService _knjigaService = KnjigaService();
  final ApiService _korisnikService = ApiService();

  @override
  void initState() {
    super.initState();
    _knjigaFuture = _knjigaService.fetchKnjigaById(widget.knjigaId);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Knjiga Details')),
      body: FutureBuilder<Knjiga>(
        future: _knjigaFuture,
        builder: (context, knjigaSnapshot) {
          if (knjigaSnapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: CircularProgressIndicator());
          } else if (knjigaSnapshot.hasError) {
            return Center(child: Text('Error: ${knjigaSnapshot.error}'));
          } else if (!knjigaSnapshot.hasData) {
            return const Center(child: Text('No details available'));
          } else {
            final knjiga = knjigaSnapshot.data!;
            _authorFuture = _korisnikService.fetchKorisnikById(knjiga.autorId);

            return FutureBuilder<Korisnik?>(
              future: _authorFuture,
              builder: (context, authorSnapshot) {
                if (authorSnapshot.connectionState == ConnectionState.waiting) {
                  return const Center(child: CircularProgressIndicator());
                } else if (authorSnapshot.hasError) {
                  return Center(child: Text('Error: ${authorSnapshot.error}'));
                } else if (!authorSnapshot.hasData) {
                  return const Center(child: Text('No author details available'));
                } else {
                  final author = authorSnapshot.data!;
                  return Padding(
                    padding: const EdgeInsets.all(16.0),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          knjiga.naslov,
                          style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
                        ),
                        const SizedBox(height: 10),
                        InkWell(
                          onTap: () {
                            Navigator.push(
                              context,
                              MaterialPageRoute(
                                builder: (context) => KorisnikDetailScreen(korisnik: author),
                              ),
                            );
                          },
                          child: Text(
                            'Author: ${author.ime} ${author.prezime}', // Display author's full name
                            style: const TextStyle(fontSize: 18, color: Colors.blue),
                          ),
                        ),
                        const SizedBox(height: 10),
                        knjiga.naslovnaSlika != null
                            ? Image.network(knjiga.naslovnaSlika!)
                            : const Placeholder(fallbackHeight: 200),
                        const SizedBox(height: 10),
                        Text(
                          'Price: ${knjiga.cijena != null ? knjiga.cijena!.toStringAsFixed(2) : 'Not available'}',
                          style: const TextStyle(fontSize: 18),
                        ),
                        const SizedBox(height: 10),
                        Text(
                          'Publication Date: ${knjiga.datumIzdavanja.toLocal().toString().split(' ')[0]}',
                          style: const TextStyle(fontSize: 18),
                        ),
                        const SizedBox(height: 10),
                        Text(
                          'Description: ${knjiga.opis ?? 'No description available'}',
                          style: const TextStyle(fontSize: 18),
                        ),
                      ],
                    ),
                  );
                }
              },
            );
          }
        },
      ),
    );
  }
}
