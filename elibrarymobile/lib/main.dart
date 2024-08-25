import 'package:flutter/material.dart';
import 'screens/register_screen.dart';
import 'screens/login_screen.dart';
import 'screens/home_screen.dart'; // Import the HomeScreen

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'eLibrary',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      initialRoute: '/login', // Set LoginScreen as the initial route
      routes: {
        '/login': (context) => const LoginScreen(), // Add route for LoginScreen
        '/register': (context) => const RegisterScreen(), // Add route for RegisterScreen
        '/home': (context) => const HomeScreen(), // Add route for HomeScreen
      },
    );
  }
}
