#include <functional>
#include <iostream>
#include <map>
#include <set>
#include <string_view>
#include <vector>

void ExecuteBlock(std::string_view title,
                  const std::function<void()>& codeBlock,
                  char separator = '=') {
  int length = 80;
  std::cout << std::endl;
  std::cout << std::endl;
  std::cout << std::string(length, separator) << std::endl;
  std::cout << title << std::endl;
  std::cout << std::string(title.length(), '-') << std::endl;

  if (codeBlock == nullptr) {
    return;
  }

  std::cout << std::endl;
  codeBlock();
  std::cout << std::endl;
  std::cout << std::endl;
}

void ExecuteBlock(std::string_view title) { ExecuteBlock(title, nullptr); }

int main() {
  ExecuteBlock("Hello, World!");

  ExecuteBlock("Vectors", []() {
    // create a vector with elements
    std::vector<int> vec = {1, 2, 3, 4, 5};
    // print the elements

    for (int i = 0; i < vec.size(); i++) {
      std::cout << vec[i] << ' ';
    }
  });

  ExecuteBlock("Hash tables", []() {
    // create a hash table
    std::map<std::string, int> hash;

    // insert a key-value pair
    hash["foo"] = 42;

    // check if a key exists
    if (hash.count("foo")) {
      std::cout << hash["foo"] << std::endl;
    }
  });

  ExecuteBlock("Hash set", []() {
    // create a hash set
    std::set<std::string> set;

    // insert a key-value pair
    set.insert("foo");
    set.insert("bar");

    // check if a key exists (c++11)
    if (set.find("foo") != set.end()) {
      std::cout << "foo exists" << std::endl;
    }

    // check if a key exists (c++20)
    if (set.contains("bar")) {
      std::cout << "bar exists" << std::endl;
    }
  });

  return 0;
}