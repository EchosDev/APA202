//1.Verilmis arrayde tekrarlanan reqemleri silmek ve tekrar reqemlerin sayini gostermek.

function removeDublicatedItems(arr) {
    let uniqueArr = []
    let duplicateCount = 0

    for (let i = 0; i < arr.length; i++) {
        if (!uniqueArr.includes(arr[i])) {
            uniqueArr.push(arr[i])
        } else {
            duplicateCount++
        }
    }

    console.log("Tekrar olmayanlar:", uniqueArr)
    console.log("Silinen tekrar sayi:", duplicateCount)
}

//2.Verilmis sozun polindrom olub olmadığını yoxlayan alqoritm yazmaq.

function isPalindrome(str) {
    let reversedStr = "";

    for (let i = str.length - 1; i >= 0; i--) {
        reversedStr += str[i];
    }

    if (str === reversedStr) {
        return true;
    } else {
        return false;
    }
}

console.log(isPalindrome("elmir"));
console.log(isPalindrome("madam"));

// 3.Girilen ededin verilmis arreyde nece elementden kicik oldugunu yazan alqoritim.

function countSmallerElements(arr, targetNumber) {
    let count = 0
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] < targetNumber) {
            count++;
        }
    }
    return count;
}

//4.Daxil edilen ededin Aboundant ve ya Deficient oldugunu yoxlayan algorithm.(Abundant ədəd öz müsbət bolenlerinin(ozunden basqa) cəmi özündən böyük olan müsbət tam ədədlərə deyilir. Eks halda Deficient eded olur. 12-Aboundant, 13- Deficient)

function checkNumberType(num) {
    let sumOfDivisors = 0;

    for (let i = 1; i < num; i++) {
        if (num % i === 0) {
            sumOfDivisors += i;
        }
    }

    if (sumOfDivisors > num) {
        console.log(num + " - Abundant ededdir");
    } else {
        console.log(num + " - Deficient ededdir");
    }
}

//5.Array-in bütün elementlərini kvadrata yüksəldib yeni array qaytaran funksiya yazın.

function squareArray(arr) {
    let squaredArr = [];
    for (let i = 0; i < arr.length; i++) {
        squaredArr.push(arr[i] * arr[i]);
    }
    return squaredArr;
}
