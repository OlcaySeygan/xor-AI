using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using oLseyLibrary;
using oLseyLibrary.Model;
using oLseyLibrary.Mathematics;

namespace XOR_Console {
    class Program {
        static void Main(string[] args) {
            NeuralNetwork neuralNetwork = new NeuralNetwork(2, 4, 2) {
                error_limit = 0.005f,
                infinite_loop = true,
                ignore_error = true,
                learning_rate = 0.5f,
                momentum_rate = 0.8f
            };

            Regression regression = new Regression("e:\\data.in", "e:\\data.out");
            
            while (neuralNetwork.Training_Loop(regression, 8)) {
                var results = neuralNetwork.Predict_TrainingData(regression);
                var out_text = "[";
                for (int i = 0; i < results.Count; i++) {
                    if (i != 0) out_text += ", ";
                    out_text += "[";
                    for (int j = 0; j < results[i].Length; j++) {
                        if (j != 0) out_text += ", ";
                        out_text += results[i][j].value;
                    }
                    out_text += "]";
                }
                out_text += "]";

                Console.WriteLine(out_text);
            }

            neuralNetwork.Dispose();
            Console.ReadKey();
        }
    }
}
