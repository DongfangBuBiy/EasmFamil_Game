import openpyxl

# تعریف دیکشنری نگاشت حروف فارسی به انگلیسی
char_mapping = {
    "آ":"7",
    "ا": "a",
    "ب": "b",
    "پ": "p",
    "ت": "t",
    "ث": "s",
    "ج": "j",
    "چ": "2",
    "ح": "h",
    "خ": "1",
    "د": "d",
    "ذ": "z",
    "ر": "r",
    "ز": "z",
    "ژ": "3",
    "س": "s",
    "ش": "4",
    "ص": "s",
    "ض": "z",
    "ط": "t",
    "ظ": "z",
    "ع": "6",
    "غ": "5",
    "ف": "f",
    "ق": "q",
    "ک": "k",
    "گ": "g",
    "ل": "l",
    "م": "m",
    "ن": "n",
    "و": "v",
    "ه": "h",
    "ی": "y",
    "ئ":"7",
    " ": " ",  # فاصله
}

# مسیر فایل Excel
file_path = "C:/Users/AsrarIT/Desktop/use exsel/united.xlsx"

# بارگذاری فایل Excel
workbook = openpyxl.load_workbook(file_path)
sheet = workbook.active


# تابع تبدیل متن فارسی به انگلیسی
def convert_to_english(text):
    result = ""
    for char in text:
        # اگر حرف در دیکشنری وجود داشت، معادل آن را اضافه کن
        if char in char_mapping:
            result += char_mapping[char]
        else:
            # اگر حرف وجود نداشت، عیناً اضافه کن (مثل علائم خاص)
            result += char
    return result


# پیمایش سطرها و تبدیل داده‌ها
for row in range(1, sheet.max_row + 1):
    # خواندن مقدار از ستون A
    persian_text = sheet[f"A{row}"].value

    if persian_text:  # اگر مقدار وجود داشت
        # تبدیل متن فارسی به انگلیسی
        english_text = convert_to_english(persian_text)

        # نوشتن مقدار در ستون B
        sheet[f"B{row}"].value = english_text

# ذخیره تغییرات در فایل Excel
workbook.save(file_path)

print("تبدیل با موفقیت انجام شد!")