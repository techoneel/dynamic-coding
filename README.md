# Dynamic Coding

## Dynamic Javascript Sample
Executing dynamic javascript code.

### Code
```
new Function('data', codeSample1_Logic)(codeSample1_Data)
```
### Input
```
// This is the code data
let codeSample1_Data = { a: 6, b: 2 };

// This is the code logic
let codeSample1_Logic = `console.log('data='+JSON.stringify(data))
let {a, b} = data
console.log('a='+a)
console.log('b='+b)
console.log('a+b='+(a+b))
console.log('a-b='+(a-b))
console.log('a*b='+a*b)
console.log('a/b='+a/b)`;
```
### Output
```
data={"a":6,"b":2}
a=6
b=2
a+b=8
a-b=4
a*b=12
a/b=3
```
### Example
https://github.com/techoneel/dynamic-js-sample/blob/main/examples/dynamic-code.js
