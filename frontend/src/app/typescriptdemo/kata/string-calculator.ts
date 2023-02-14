export class StringCalculator {
  add(numbers: string) {
    if (numbers === '') return 0;

    var digits = numbers.split(',');
    var result = 0;

    digits.forEach((digit) => {
      result += parseInt(digit);
    });

    return result;
  }
}
