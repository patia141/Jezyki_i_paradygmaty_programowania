import re
from collections import Counter

def analiza_tekstu(text):
    paragraphs = text.strip().split('\n')
    num_paragraphs = len([p for p in paragraphs if p.strip()])

    sentences = re.split(r'[.!?]+', text)
    num_sentences = len([s for s in sentences if s.strip()])

    words = re.findall(r'\b\w+\b', text)
    num_words = len(words)

    stop_words = {'i', 'o', 'a', 'z', 'w', 'u'}
    filtered_words = [word.lower() for word in words if word.lower() not in stop_words]
    most_common_words = Counter(filtered_words).most_common(5)

    transformed_words = [
        word[::-1] if word.lower().startswith('a') else word
        for word in words
    ]
    transformed_text = ' '.join(transformed_words)

    return {
        "num_paragraphs": num_paragraphs,
        "num_sentences": num_sentences,
        "num_words": num_words,
        "most_common_words": most_common_words,
        "transformed_text": transformed_text
    }


tekst = (
    "Apple Programowanie funkcyjne – filozofia i metodyka programowania będąca odmianą "
    "programowania deklaratywnego, w której wykorzystuje się to, że funkcje należą do "
    "typów pierwszoklasowych. Kładzie się nacisk na obliczanie wartości funkcji (często "
    "rekurencyjnych), ich kompozycje oraz funkcje wyższego rzędu anomalia."
)

wynik = analiza_tekstu(tekst)

print("Liczba akapitów:", wynik["num_paragraphs"])
print("Liczba zdań:", wynik["num_sentences"])
print("Liczba słów:", wynik["num_words"])
print("Najczęściej występujące słowa (bez stop words):", wynik["most_common_words"])
print("Przetransformowany tekst:\n", wynik["transformed_text"])
