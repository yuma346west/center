'use strict';
const {
  Model
} = require('sequelize');
module.exports = (sequelize, DataTypes) => {
  class MCard extends Model {
    /**
     * Helper method for defining associations.
     * This method is not a part of Sequelize lifecycle.
     * The `models/index` file will call this method automatically.
     */
    static associate(models) {
      // define association here
    }
  };
  MCard.init({
    id: DataTypes.INTEGER,
    name: DataTypes.STRING,
    color: DataTypes.SMALLINT,
    level: DataTypes.SMALLINT,
    cost: DataTypes.SMALLINT,
    power: DataTypes.SMALLINT,
    soul: DataTypes.SMALLINT,
    skill_description: DataTypes.TEXT
  }, {
    sequelize,
    modelName: 'MCard',
  });
  return MCard;
};