# Zadanie 1. Analiza Tekstu i Transformacje Funkcyjne
# Napisz program, który przyjmuje długi tekst (np. artykuł, książkę) i wykonuje kilka złożonych operacji
# analizy tekstu:
# • Zlicza liczbę słów, zdań, i akapitów w tekście.
# • Wyszukuje najczęściej występujące słowa, wykluczając tzw. stop words (np. "i", "a", "the").
# • Transformuje wszystkie wyrazy rozpoczynające się na literę "a" lub "A" do ich odwrotności (np.
# "apple" → "elppa").
# Wskazówka: Użyj map(), filter(), i list składanych, aby przeprowadzać transformacje na tekście.
import re

def analyze_and_transform_text(text):
    words = re.findall(r"\b\w+(?:'\w+)?\b", text.lower())
    word_count = len(words)
    regex = re.split(r'[.!?,]', text)
    sentence_list = [text.strip() for text in regex if text.split()]
    sentence_count = len(sentence_list)
    paragraph_count = len(list(filter(lambda x: x == '\n', text))) + 1
    stop_words = {
        "i", "a", "an", "the", "and", "or", "of", "to", "in", "on", "with", "for", "at", "by", "from",
        "is", "it", "that", "this", "be", "are", "was", "were", "as", "but", "not", "have", "has"
    }
    filtered_words = [word for word in words if word not in stop_words]
    word_counts = {}
    for word in filtered_words:
        if word in word_counts:
            word_counts[word] += 1
        else:
            word_counts[word] = 1

    sorted_words = sorted(word_counts.items(), key=lambda x: x[1], reverse=True)
    max_count = sorted_words[0][1]
    most_common_words = [word for word, count in sorted_words if count == max_count]
    transformed_text = re.sub(r"\b\w+(?:'\w+)?\b",
                              lambda match: match.group(0)[::-1] if match.group(0).lower().startswith(
                                  'a') else match.group(0),
                              text)
    return word_count, sentence_count, paragraph_count, most_common_words, transformed_text



text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
word_count, sentence_count, paragraph_count, most_common_words, transformed_text = analyze_and_transform_text(text)
print(f"Liczba słów: {word_count}\nLiczba zdań: {sentence_count}\nLiczba_akapitów: {paragraph_count}\nNajczęstsze słowo: {most_common_words}\nTekst po transformacji:\n{transformed_text}")
