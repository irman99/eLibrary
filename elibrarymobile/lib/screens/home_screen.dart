import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:elibrarymobile/models/knjiga.dart';
import 'package:elibrarymobile/services/knjiga_service.dart'; // Import the service
import '/widgets/bottom_bar.dart'; // Import the BottomBar widget
import '/widgets/app_bar.dart'; // Import the AppBar widget
import '/screens/knjiga_detail_screen.dart'; // Import the KnjigaDetailScreen
import '/widgets/year_picker.dart' as custom_year_picker; // Import the custom YearPicker

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  int _selectedIndex = 0;
  late Future<List<Knjiga>> _knjigeFuture; // Declare Future for knjige
  final KnjigaService _knjigaService = KnjigaService(); // Instantiate the service

  final TextEditingController _titleController = TextEditingController();
  DateTime? _selectedYear;

  @override
  void initState() {
    super.initState();
    _knjigeFuture = _knjigaService.fetchKnjige(); // Initialize the Future
  }

  void _onTabSelected(int index) {
    setState(() {
      _selectedIndex = index;
    });

    // Handle navigation based on the selected index
    switch (index) {
      case 0:
      // Navigate to Home
        break;
      case 1:
      // Navigate to Notifications
        break;
      case 2:
      // Handle Add Button
        break;
      case 3:
      // Navigate to Library
        break;
      case 4:
      // Navigate to Account
        break;
    }
  }

  void _applyFilters() {
    setState(() {
      _knjigeFuture = _knjigaService.fetchKnjige(
        naslov: _titleController.text,
        datumIzdavanja: _selectedYear != null
            ? DateFormat('yyyy-MM-dd').format(DateTime(_selectedYear!.year, 1, 1))
            : null,
      );
    });
  }

  Future<void> _selectYear() async {
    final DateTime? selectedDate = await showDialog<DateTime>(
      context: context,
      builder: (BuildContext context) {
        return custom_year_picker.CustomYearPicker(
          firstDate: DateTime(1900),
          lastDate: DateTime.now(),
          selectedDate: _selectedYear ?? DateTime.now(),
          onChanged: (DateTime date) {
            Navigator.of(context).pop(date);
          },
        );
      },
    );

    print('Selected Date: $selectedDate'); // Debugging line

    if (selectedDate != null) {
      setState(() {
        _selectedYear = selectedDate;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: buildAppBar(),
      body: _selectedIndex == 0
          ? Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: _titleController,
                    decoration: const InputDecoration(
                      labelText: 'Title',
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                const SizedBox(width: 8.0),
                ElevatedButton(
                  onPressed: _selectYear,
                  child: Text(_selectedYear != null
                      ? 'Year: ${_selectedYear!.year}'
                      : 'Select Year'),
                ),
              ],
            ),
          ),
          ElevatedButton(
            onPressed: _applyFilters,
            child: const Text('Apply Filters'),
          ),
          Expanded(
            child: FutureBuilder<List<Knjiga>>(
              future: _knjigeFuture, // Use the Future from initState
              builder: (context, snapshot) {
                if (snapshot.connectionState == ConnectionState.waiting) {
                  return const Center(child: CircularProgressIndicator());
                } else if (snapshot.hasError) {
                  return Center(child: Text('Error: ${snapshot.error}'));
                } else if (!snapshot.hasData || snapshot.data!.isEmpty) {
                  return const Center(child: Text('No knjige available'));
                } else {
                  final knjige = snapshot.data!;
                  return ListView.builder(
                    padding: const EdgeInsets.all(8.0),
                    itemCount: knjige.length,
                    itemBuilder: (context, index) {
                      final knjiga = knjige[index];
                      return Padding(
                        padding: const EdgeInsets.symmetric(vertical: 8.0),
                        child: ListTile(
                          contentPadding: const EdgeInsets.all(8.0),
                          leading: knjiga.naslovnaSlika != null
                              ? Image.network(
                            knjiga.naslovnaSlika!,
                            width: 100,
                            height: 150,
                            fit: BoxFit.cover,
                          )
                              : const SizedBox(
                            width: 100,
                            height: 150,
                            child: Placeholder(),
                          ),
                          title: Text(
                            knjiga.naslov,
                            style: const TextStyle(
                              fontSize: 18,
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                          subtitle: knjiga.cijena != null
                              ? Text(
                            'Price: \$${knjiga.cijena!.toStringAsFixed(2)}',
                            style: const TextStyle(
                              fontSize: 16,
                              color: Colors.green,
                            ),
                          )
                              : null,
                          onTap: () {
                            Navigator.push(
                              context,
                              MaterialPageRoute(
                                builder: (context) => KnjigaDetailScreen(knjigaId: knjiga.id),
                              ),
                            );
                          },
                        ),
                      );
                    },
                  );
                }
              },
            ),
          ),
        ],
      )
          : Center(child: Text('Content for tab $_selectedIndex')),
      bottomNavigationBar: BottomBar(
        onTabSelected: _onTabSelected,
        currentIndex: _selectedIndex,
      ),
    );
  }
}
