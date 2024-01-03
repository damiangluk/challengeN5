import * as Yup from "yup";

const textRequired = Yup.string().required("This field is required");

const dateRequired = Yup.date().required("This field is required").typeError("Please select a valid date").nullable()

const Validations = {
  textRequired,
  dateRequired,
};

export default Validations