import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';

class CustomYearPicker extends StatelessWidget {
  final DateTime firstDate;
  final DateTime lastDate;
  final DateTime? selectedDate;
  final ValueChanged<DateTime> onChanged;
  final DragStartBehavior dragStartBehavior;

  const CustomYearPicker({
    Key? key,
    required this.firstDate,
    required this.lastDate,
    required this.selectedDate,
    required this.onChanged,
    this.dragStartBehavior = DragStartBehavior.start,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Dialog(
      child: YearPicker(
        firstDate: firstDate,
        lastDate: lastDate,
        selectedDate: selectedDate,
        onChanged: onChanged,
        dragStartBehavior: dragStartBehavior,
      ),
    );
  }
}
