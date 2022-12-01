use std::fs;

fn main() {
	const INPUT_PATH: &str = "/Volumes/Blue/Temp/input.txt";

    let raw_data = read_input_file(INPUT_PATH);

	println!("\n\nSolution (part 1): \x1b[92m{}\x1b[0m", solve1(raw_data.clone()));
	println!("Solution (part 2): \x1b[92m{}\x1b[0m", solve2(raw_data.clone()));

}

fn read_input_file(path:&str) -> String {
    let contents = fs::read_to_string(path)
        .expect("reading input file");

	return contents;
}

fn solve1(raw_data: String) -> String {

	let mut max = 0;
	let mut cur: i32 = 0;
	for s1 in raw_data.split("\n\n") {
		cur=0;
		for s2 in s1.split_whitespace() {
			cur+= s2.parse::<i32>().unwrap();
		}
		if cur>max {
			max=cur;
		}
	}
	return max.to_string();
}

fn solve2(raw_data: String) -> String {

	let mut vec = Vec::new();
	let mut cur: i32 = 0;

	for s1 in raw_data.split("\n\n") {
		cur=0;
		for s2 in s1.split_whitespace() {
			cur+= s2.parse::<i32>().unwrap();
		}
		vec.push(cur);
	}
	vec.sort_by(|a, b| b.cmp(a));

	return (vec[0]+vec[1]+vec[2]).to_string();
}
