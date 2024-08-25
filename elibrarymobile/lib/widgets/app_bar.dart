import 'package:flutter/material.dart';

AppBar buildAppBar() {
  return AppBar(
    title: SizedBox(
      width: double.infinity, // Make the container span the width of the AppBar
      child: Image.asset(
        'lib/assets/images/logo.png', // Ensure the path is correct
        fit: BoxFit.contain, // Adjust fit to maintain aspect ratio
        height: 50, // Set the desired height for the logo
      ),
    ),
    centerTitle: true,
    backgroundColor: Colors.transparent, // Makes the AppBar background transparent
    elevation: 0, // Removes the shadow/elevation
  );
}