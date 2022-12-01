use std::error::Error;
use std::fs;

pub struct Config {}
impl Config{}

pub fn read_input(path:&str)  -> Result<(), Box<dyn Error>> {
	//let file_path = "/Users/brentbordelon/Downloads/input.txt";
	println!("In file {}", path);
    let contents = fs::read_to_string(path)
        .expect("Should have been able to read the file");

    println!("With text:\n{contents}");
	Ok(())
}

pub fn solve()  -> Result<(), Box<dyn Error>> {
	let file_path = "/Users/brentbordelon/Downloads/input.txt";
	println!("In file {}", file_path);
    let contents = fs::read_to_string(file_path)
        .expect("Should have been able to read the file");

    println!("With text:\n{contents}");
	Ok(())
}