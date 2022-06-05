import axios from "axios";

const baseURL = "https://localhost:7033/api";

const getArchive = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Archive`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

  export default getArchive;