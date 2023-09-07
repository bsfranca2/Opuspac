export const generateAvatarName = (name: string): string => {
  const names = name.trim().split(" ");
  if (names.length === 1) {
    return names[0][0].toUpperCase();
  } else if (names.length >= 2) {
    return `${names[0][0].toUpperCase()}${names[names.length - 1][0].toUpperCase()}`;
  } else {
    return "";
  }
};
