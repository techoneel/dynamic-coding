# 🚀 Dynamic Coding

A reference guide on **dynamic code execution across multiple programming languages**.
This shows how code can be executed directly from a **string**, either natively or through runtime compilation.

---

## 🔑 Overview

Not all languages allow **direct execution of code strings**. Some provide `eval` or similar features natively, while others require compiling code on the fly.

### ✅ Languages with **native support**

* **JavaScript** (`eval`, `new Function`)
* **Python** (`exec`, `eval`)
* **Ruby** (`eval`)
* **PHP** (`eval`)
* **Lisp-family languages** (e.g., Clojure)

### ⚠️ Languages requiring **compilation or scripting APIs**

* Java
* C#
* C++
* Go
* Kotlin
* Swift
* Rust

---

## 🧩 How It Works

### 1. JavaScript (native support)

```javascript
let code = `
  let {a, b} = data;
  console.log("Sum =", a+b);
  console.log("Product =", a*b);
`;
new Function("data", code)({a:6, b:2});
```

---

### 2. Python (native support)

```python
code = """
a = data['a']
b = data['b']
print("Sum =", a+b)
print("Product =", a*b)
"""

data = {"a": 6, "b": 2}
exec(code)
```

---

### 3. Ruby (native support)

```ruby
code = "
a = data[:a]
b = data[:b]
puts \"Sum = #{a+b}\"
puts \"Product = #{a*b}\"
"

data = {a: 6, b: 2}
eval(code)
```

---

### 4. PHP (native support)

```php
<?php
$code = '
$a = $data["a"];
$b = $data["b"];
echo "Sum = " . ($a + $b) . "\n";
echo "Product = " . ($a * $b) . "\n";
';

$data = ["a" => 6, "b" => 2];
eval($code);
?>
```

---

### 5. Java (via compiler API, not native)

// Requires `javax.tools.JavaCompiler` API (JSR-199).
// Dynamically compile and execute code strings.

---

### 6. C# (via Roslyn Scripting API)

```csharp
// Requires Microsoft.CodeAnalysis.CSharp.Scripting
using Microsoft.CodeAnalysis.CSharp.Scripting;

var code = @"
var sum = data[""a""] + data[""b""];
Console.WriteLine($""Sum = {sum}"");
";

var data = new Dictionary<string,int>{{"a",6},{"b",2}};
await CSharpScript.EvaluateAsync(code, globals: new { data });
```

---

### 7. C++ (no eval, needs external compiler)

* Write code to a `.cpp` file.
* Compile with `g++` → run the binary.

---

### 8. Go (no eval, needs runtime compiler)

* Write code to a `.go` file.
* Execute via `go run temp.go`.

---

### 9. Kotlin (via scripting API)

// Requires `kotlin.script.experimental` package.

---

### 10. Swift (via interpreter)

* Use `swift -` to feed and run code strings.

---

### 11. Rust (no eval, needs compiler)

* Write code string to `.rs` file.
* Compile using `rustc temp.rs`.
* Execute binary.

---

## 📌 JavaScript Example (Detailed)

This repository includes a working example of dynamic code execution in **JavaScript**.

### Code

```javascript
new Function('data', codeSample1_Logic)(codeSample1_Data)
```

### Input

```javascript
// Code data
let codeSample1_Data = { a: 6, b: 2 };

// Code logic
let codeSample1_Logic = `
console.log('data='+JSON.stringify(data))
let {a, b} = data
console.log('a='+a)
console.log('b='+b)
console.log('a+b='+(a+b))
console.log('a-b='+(a-b))
console.log('a*b='+(a*b))
console.log('a/b='+(a/b))
`;
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

---

## 📖 Example Repository

👉 [Dynamic Code in JavaScript (GitHub Example)](https://github.com/techoneel/dynamic-js-sample/blob/main/examples/dynamic-code.js)

---

## ⚡ Summary

* **Dynamic execution** is simple in scripting languages (JS, Python, Ruby, PHP).
* **Compiled languages** need special handling (APIs, interpreters, compilers).
* Use cases:
  * Sandboxed script execution
  * Plugins and customization
  * Learning and experimentation
