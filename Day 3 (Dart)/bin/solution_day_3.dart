import 'dart:io';

// ignore: depend_on_referenced_packages
import 'package:collection/src/iterable_extensions.dart';

void main(List<String> arguments) {
  var path = '/Volumes/Blue/Temp/input.txt';
  var solution = 0;

  // read file lines (rucksacks)
  var lines = File(path).readAsLinesSync();

  // loop through each rucksack
  for (final rucksack in lines) {
    // split the 'rucksack' string into two compartments:
    var len = rucksack.length ~/ 2;
    var comp1 = rucksack.substring(0, len).split('');
    var comp2 = rucksack.substring(len).split('');

    // look for each item in comp1 in comp2 for a match
    for (final c1 in comp1) {
      var c = comp2.firstWhereOrNull((c2) => c2 == c1);
      if (c != null) {
        // get the priority based off of its ascii value
        var ascii = c.codeUnitAt(0);
        var priority = ascii < 97 ? ascii - 38 : ascii - 96;
        // sum up
        solution += priority;
        break;
      }
    }
  }
  print('Solution 1: \x1b[92m$solution\x1b[0m');

  solution = 0;
  for (var i = 0; i < lines.length; i += 3) {
    var l1 = lines[i].split('');
    var l2 = lines[i + 1].split('');
    var l3 = lines[i + 2].split('');

    // look for each item in l1 in l2 for a match
    for (final c1 in l1) {
      var c = l2.firstWhereOrNull((c2) => c2 == c1);
      if (c != null) {
        // look for a match in l3
        var d = l3.firstWhereOrNull((c3) => c3 == c);
        if (d != null) {
          // get the priority based off of its ascii value
          var ascii = d.codeUnitAt(0);
          var priority = ascii < 97 ? ascii - 38 : ascii - 96;
          // sum up
          solution += priority;
          break;
        }
      }
    }
  }
  print('Solution 2: \x1b[92m$solution\x1b[0m');
}
