export const constructErrorDetail = (error: any): any => {
  if (typeof error === "string") {
    return error;
  }
  if (error?.errors) {
    return JSON.stringify(error.errors)
  }
  if(typeof error === 'object') {
    let errorString = '';
    Object.entries(error).forEach(([key, value]) => {
      errorString += `${key}: ${simplifyArrayString(value as [])},`
    })
    return errorString;
  }

  return "";
};

const simplifyArrayString = (arr:[]) => {
  return JSON.stringify(arr).slice(1, -1).replace(/"/g, '');
};