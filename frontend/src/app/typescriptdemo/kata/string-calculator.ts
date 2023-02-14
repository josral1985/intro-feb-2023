import { NoNegativesAllowedExecption } from './NoNegativesAllowedException';

export class StringCalculator {
  add(numbers: string) {
    if (numbers === '') return 0;

    var delim;
    var negativeNums: string[];

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
      if (digit.includes('-')) {
        throw new NoNegativesAllowedExecption('No Negatives Allowed ' + digit);
      }
      result += parseInt(digit);
    });

    return result;
  }
}
