import { NoNegativesAllowedException } from './NoNegativesAllowedException';

export class StringCalculator {
  add(numbers: string) {
    if (numbers === '') return 0;

    var delim;
    var negativeNums: string[] = [];

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
        negativeNums.push(digit);
      }
      result += parseInt(digit);
    });

    if (negativeNums.length > 0) {
      var msg = 'No Negatives Allowed';
      for (let idx = 0; idx < negativeNums.length; idx++) {
        const negativeNum = negativeNums[idx];

        if (idx === negativeNums.length - 1) {
          msg += ' ' + negativeNum;
        } else {
          msg += ' ' + negativeNum + ',';
        }
      }
      throw new NoNegativesAllowedException(msg);
    }

    return result;
  }
}
