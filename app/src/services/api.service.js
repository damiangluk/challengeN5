import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:44309/',
});

const getOptions = () => {
  const options = {
    'Content-Type': 'application/json',
    headers: {
      Accept: 'application/json',
    },
  };
  return options;
};

export const post = async (url, params = {}) => {
  try {
    const { data } = await api.post(url, params, getOptions());
    return JSON.parse(data);
  } catch (error) {
    console.log(error);
    return error;
  }
};

export const get = async (url) => {
  try {
    const {data} = await api.get(url, getOptions());
    return JSON.parse(data);
  } catch (error) {
    console.log(error);
    return error;
  }
};
