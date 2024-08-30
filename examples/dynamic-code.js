console.log("Executing dynamic javascript code.");

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

/**
 * This function able to run your code logic
 * with your code logic and it's required data
 * 
 * @param data
 * @param code
 */
function runDynamicCode(code, data) {
  try {
     console.log('-----------------\nInput:')
     console.log(`Running the below code:\n--\n${code}\n--\nWith the following data:\n${JSON.stringify(data)}`)
     console.log('-----------------\nOutput:')
     const func = new Function('data', code);
     func(data)
  } catch (error) {
    throw error;
  }
}

// Run the runDynamicCode function
runDynamicCode(codeSample1_Logic, codeSample1_Data)
