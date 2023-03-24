#include <iostream>
#include <algorithm>
using namespace std;

int main() {
    int N, M;
    cin >> N >> M;
    int arr[M];
    for (int i = 0; i < M; i++) {
        cin >> arr[i];
    }
    sort(arr, arr + M);
    int ink = 0;
    int start = 0;
    for (int i = 0; i < M; i++) {
        if (arr[i] == start + 1) {
            start = arr[i];
            continue;
        }
        if (arr[i] == start) continue;
        int end = arr[i] - 1;
        if (end - start <= 2) {
            ink += 5 + 2 * (end - start + 1);
        } else {
            ink += 5 + 2 * (start - end + 1);
            ink += 5 + 2 * (end - start - 1);
        }
        start = arr[i];
    }
    if (N != start) {
        if (N - start <= 2) {
            ink += 5 + 2 * (N - start);
        } else {
            ink += 5 + 2 * (start - N + 1);
            ink += 5 + 2 * (N - start - 1);
        }
    }
    cout << ink << endl;
}