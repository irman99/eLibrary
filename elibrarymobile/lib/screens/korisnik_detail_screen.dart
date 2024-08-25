import 'package:flutter/material.dart';
import '../models/korisnik.dart';

class KorisnikDetailScreen extends StatelessWidget {
  final Korisnik korisnik;

  const KorisnikDetailScreen({super.key, required this.korisnik});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('${korisnik.korisnickoIme}')),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            // Display photo if available
            if (korisnik.fotografija != null)
              Image.network(
                korisnik.fotografija!,
                height: 200, // Adjust height as needed
                width: double.infinity,
                fit: BoxFit.cover,
              )
            else
              const Placeholder(
                fallbackHeight: 200,
                fallbackWidth: double.infinity,
              ),
            const SizedBox(height: 10),
            Text('Name: ${korisnik.ime} ${korisnik.prezime}', style: const TextStyle(fontSize: 18)),
            const SizedBox(height: 10),
            Text('Email: ${korisnik.email}', style: const TextStyle(fontSize: 18)),
            const SizedBox(height: 10),
            Text('Username: ${korisnik.korisnickoIme}', style: const TextStyle(fontSize: 18)),
            const SizedBox(height: 10),
            Text('Date of Birth: ${korisnik.datumRodjenja}', style: const TextStyle(fontSize: 18)),
          ],
        ),
      ),
    );
  }
}
