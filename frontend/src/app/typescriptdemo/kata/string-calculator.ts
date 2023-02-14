export class StringCalculator {
  add(numbers: string) {
    if (numbers === '') return 0;

    var delim;

    if (numbers.startsWith('//')) {
      var newDelim = numbers[2] + '|,|\n';
      delim = new RegExp(newDelim); //regex! this is pretty cool!
      numbers = numbers.substring(4);
    } else {
      delim = /,|\n/;
    }

    var digits = numbers.split(delim);
    var result = 0;

    digits.forEach((digit) => {
      result += parseInt(digit);
    });

    return result;
  }
}
