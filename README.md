# UwuScript
World's first uwu-oriented language.

![Logo](https://github.com/lambdacasserole/uwuscript/raw/master/assets/logo.png)

Saw [a tweet](https://twitter.com/UwyBBQ/status/757959990359523328) from [Uwy](https://github.com/Uwy) and thought it'd be a tasty little meme morsel to actually build with a tokenizer I have lying around. It's basically [Brainfuck](https://en.wikipedia.org/wiki/Brainfuck) but with a special token for single-line comments. If you're looking for the plain old Brainfuck interpreter I wrote in C#, it's called [ByteRibbon](https://github.com/lambdacasserole/byteribbon).

Here's a hello world program in UwuScript:

```
uwu uwu uwu uwu uwu uwu uwu uwu uwu uwu ow< >w> uwu uwu uwu uwu uwu uwu uwu >w> *w* Comment!
uwu uwu uwu uwu uwu uwu uwu uwu uwu uwu >w> uwu uwu uwu >w> uwu <w< <w< <w< <w< 
nwn >wo >w> uwu uwu owo >w> uwu owo uwu uwu uwu uwu uwu uwu uwu owo owo uwu uwu 
uwu owo >w> uwu uwu owo <w< <w< uwu uwu uwu uwu uwu uwu uwu uwu uwu uwu uwu uwu 
uwu uwu uwu owo >w> owo uwu uwu uwu owo nwn nwn nwn nwn nwn nwn owo nwn nwn nwn 
nwn nwn nwn nwn nwn owo >w> uwu owo >w> owo *w* Hello world!
```

The following table is straight from Wikipedia, but modified for UwuScript:

|  UwuScript  |  Brainfuck  | Meaning                                                                                                                                                                           |
|-------------|-------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `>w>`       | `>`         | Increment the data pointer (to point to the next cell to the right).                                                                                                              |
| `<w<`       | `<`         | Decrement the data pointer (to point to the next cell to the left).                                                                                                               |
| `uwu`       | `+`         | Increment (increase by one) the byte at the data pointer.                                                                                                                         |
| `nwn`       | `-`         | Decrement (decrease by one) the byte at the data pointer.                                                                                                                         |
| `owo`       | `.`         | Output the byte at the data pointer.                                                                                                                                              |
| `-w-`       | `,`         | Accept one byte of input, storing its value in the byte at the data pointer.                                                                                                      |
| `ow<`       | `[`         | If the byte at the data pointer is zero, then instead of moving the instruction pointer forward to the next command, jump it forward to the command after the matching ] command. |
| `>wo`       | `]`         | If the byte at the data pointer is nonzero, then instead of moving the instruction pointer forward to the next command, jump it back to the command after the matching [ command. |
| `*w*`       | `N/A`       | Denotes a single-line comment.                                                                                                                                                    |

You're essentially manipulating a [Turing machine](https://en.wikipedia.org/wiki/Turing_machine) to produce output. Anything written in Brainfuck is obviously trivial to port to UwuScript.

## Usage

Compile the project in Visual Studio, run it like this:

```
UwuScript.exe "examples/hello.uwu"
```

## Limitations

Random inline text will break the tokenizer, that's why the single-line comment token was added.
